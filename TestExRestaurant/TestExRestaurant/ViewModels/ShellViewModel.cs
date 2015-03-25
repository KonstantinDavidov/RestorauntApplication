using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using ReactiveUI;
using TestExRestaurant.Model;
using TestExRestaurant.Resources;
using TestExRestaurant.Utils;

namespace TestExRestaurant
{
    /// <summary>
    /// View model class
    /// </summary>
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        #region Variables

        private string _filterString;
        private string _statementText;
        private bool _isSearchStarted;

        private ObservableCollection<Category> _categoryCollection;
        private ObservableCollection<Dish> _dishCollection;

        private List<Category> _categoryTempCollection;
        private List<Dish> _dishTempCollection; 

        private bool _canRemoveDish;
        private bool _canRemoveCategory;

        #endregion

        #region Constructors

        public ShellViewModel()
        {
            this.WhenAny(x => x.FilterString, x => x.Value) //When FilterString asign value, do search or restore items
                .Subscribe(x =>
                {
                    if (!string.IsNullOrEmpty(x))
                    {
                        IsSearchStarted = true;
                        Find(FilterString.ToLower(), CategoryCollection);
                        Find(FilterString.ToLower(), DishCollection);
                    }
                    else
                    {
                        RestoreItems(_categoryTempCollection, CategoryCollection);
                        RestoreItems(_dishTempCollection, DishCollection);
                        IsSearchStarted = false;
                        _dishTempCollection = null;
                        _categoryTempCollection = null;
                    }
                });
        }

        #endregion

        #region Properties

        /// <summary>
        /// Represents status of running operations to UI
        /// </summary>
        public string StatementText
        {
            get { return _statementText; }
            set
            {
                if (string.Equals(value, _statementText)) return;
                _statementText = value;
                NotifyOfPropertyChange(() => StatementText);
            }
        }

        /// <summary>
        /// Represents a property which indicates 'is search started'
        /// </summary>
        public bool IsSearchStarted
        {
            get { return _isSearchStarted; }
            set
            {
                _isSearchStarted = value;
                NotifyOfPropertyChange(() => IsSearchStarted);
            }
        }

        /// <summary>
        /// Show the ability to remove category item
        /// </summary>
        public bool CanRemoveCategory
        {
            get { return _canRemoveCategory; }
            set
            {
                if (_canRemoveCategory == value) return;
                _canRemoveCategory = value;
                NotifyOfPropertyChange(() => CanRemoveCategory);
            }
        }

        /// <summary>
        /// Show the ability to remove dish item
        /// </summary>
        public bool CanRemoveDish
        {
            get { return _canRemoveDish; }
            set
            {
                if (_canRemoveDish == value) return;
                _canRemoveDish = value;
                NotifyOfPropertyChange(() => CanRemoveDish);
            }
        }

        /// <summary>
        /// Input string for filter items
        /// </summary>
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                NotifyOfPropertyChange(() => FilterString);
            }
        }

        /// <summary>
        /// Collection which represents dish elements to UI
        /// </summary>
        public ObservableCollection<Dish> DishCollection
        {
            get
            {
                return _dishCollection ??
                        (_dishCollection = new ObservableCollection<Dish>(RestaurantManager.GetDishes()));
            }
        }

        /// <summary>
        /// Collection which represents category elements to UI
        /// </summary>
        public ObservableCollection<Category> CategoryCollection
        {
            get
            {
                return _categoryCollection ??
                       (_categoryCollection = new ObservableCollection<Category>(RestaurantManager.GetCategories()));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Restore items from temporary collections after searching
        /// </summary>
        /// <typeparam name="T">Type of elements</typeparam>
        /// <param name="tempCollection">Temporary collection which contain items before searching</param>
        /// <param name="sourceCollection">Collection which represents items of type T to UI></param>
        private void RestoreItems<T>(IEnumerable<T> tempCollection, ObservableCollection<T> sourceCollection)
        {
            if (tempCollection == null) return;

            sourceCollection.Clear();

            foreach (var item in tempCollection)
            {
                sourceCollection.Add(item);
            }
        }

        /// <summary>
        /// Find elements in source collection. Search based on filter string
        /// </summary>
        /// <param name="filterString">Input string to search. Get this from textbox</param>
        /// <param name="sourceCollection">Collection in which we are searching</param>
        private void Find(string filterString, ObservableCollection<Category> sourceCollection)
        {
            if (IsSearchStarted && _categoryTempCollection == null)
                _categoryTempCollection = sourceCollection.ToList();

            List<Category> resultCollection = sourceCollection.Where(x => 
                                                                    x.Name != null && x.Name.Contains(filterString))
                                                                    .ToList();

            sourceCollection.Clear();

            foreach (var item in resultCollection)
            {
                sourceCollection.Add(item);
            }
        }

        /// <summary>
        /// Find elements in source collection. Search based on filter string
        /// </summary>
        /// <param name="filterString">Input string to search. Get this from textbox</param>
        /// <param name="sourceCollection">Collection in which we are searching</param>
        public void Find(string filterString, ObservableCollection<Dish> sourceCollection)
        {
            if (IsSearchStarted && _dishTempCollection == null)
                _dishTempCollection = sourceCollection.ToList();
            
            List<Dish> resultCollection = sourceCollection.Where(x =>
                                                                (x.Name != null && x.Name.Contains(filterString)) ||
                                                                x.Price.ToString().Contains(filterString) ||
                                                                (x.Category != null && (x.Category.Name != null && x.Category.Name.Contains(filterString))) // (x.Category.Name ?? x.Category.Name.Contains(filterString)))
                                                                ).ToList();

            sourceCollection.Clear();

            foreach (var item in resultCollection)
            {
                sourceCollection.Add(item);
            }
        }

        /// <summary>
        /// Add new Dish item
        /// </summary>
        public void AddDish()
        {
            DishCollection.Add(new Dish());
        }

        /// <summary>
        /// Add new category item
        /// </summary>
        public void AddCategory()
        {
            CategoryCollection.Add(new Category());
        }

        /// <summary>
        /// Remove dish item from UI collection
        /// </summary>
        /// <param name="selectedDish">Element which will be deleted</param>
        public void RemoveDish(Dish selectedDish)
        {
            DishCollection.Remove(selectedDish);
        }

        /// <summary>
        /// Remove category item and appropriate items from UI collection
        /// </summary>
        /// <param name="selectedCategory">Element which will be deleted</param>
        public void RemoveCategory(Category selectedCategory)
        {
            MessageBoxResult rsltMessageBox = MessageBox.Show(Messages.WarningText, Messages.WarningCaption, MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (rsltMessageBox == MessageBoxResult.Yes)
            {
                DishCollection.RemoveAll(x =>
                                            x.Category != null && 
                                            x.Category.Name != null &&
                                            x.Category.Name.Equals(selectedCategory.Name));

                CategoryCollection.Remove(selectedCategory);
            }
        }

        /// <summary>
        /// Load and deserialize file from standart directory
        /// </summary>
        public void LoadFile()
        {
            try
            {
                RestaurantManager.LoadFile();
                Update();
                StatementText = Messages.Loaded;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Save and serialize file to standart directory
        /// </summary>
        public void SaveFile()
        {
            try
            {
                Observable.Start(
                    () => RestaurantManager.SaveFile(DishCollection.ToList(), CategoryCollection.ToList()))
                         .Finally(() => StatementText = Messages.Saved).Subscribe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Add user file and add items from file to UI
        /// </summary>
        public void AppendData()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Filter = "Text files (*.txt)|*.txt|XML files (*.xml)|*.xml";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    RestaurantManager.LoadFile(dlg.FileName);
                    Update();
                    StatementText = Messages.Appended;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Update UI collections
        /// </summary>
        private void Update()
        {
            CategoryCollection.Clear();
            DishCollection.Clear();

            Application.Current.Dispatcher.BeginInvoke((System.Action)(() =>
            {
                foreach (var category in RestaurantManager.GetCategories())
                {
                    CategoryCollection.Add(category);
                }

                foreach (var dish in RestaurantManager.GetDishes())
                {
                    DishCollection.Add(dish);
                }
            }));
        }

        /// <summary>
        /// Check the ability to remove Dish item
        /// </summary>
        /// <param name="selectedItem">Selected Dish item</param>
        public void DishSelectionChanged(Dish selectedItem)
        {
            CanRemoveDish = selectedItem != null;
        }

        /// <summary>
        /// Check the ability to remove Category item
        /// </summary>
        /// <param name="selectedItem">Selected Category item</param>
        public void CategorySelectionChanged(Category selectedItem)
        {
            CanRemoveCategory = selectedItem != null;
        }

        #endregion
    }
}