using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestExRestaurant.Utils;

namespace TestExRestaurant.Model
{
    /// <summary>
    /// Manager of our Restaurant
    /// </summary>
    public static class RestaurantManager
    {
        #region Variables

        /// <summary>
        /// Path of the output file
        /// </summary>
        private const string FileName = "OutputFile.txt";

        private static List<Dish> _dishCollection;
        private static List<Category> _categoryCollection;

        #endregion

        #region Constructors

        /// <summary>
        /// Default contructor wich initialize collections
        /// </summary>
        static RestaurantManager()
        {
            _dishCollection = new List<Dish>();
            _categoryCollection = new List<Category>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get collection of dishes
        /// </summary>
        /// <returns></returns>
        public static List<Dish> GetDishes()
        {
            return _dishCollection;
        }

        /// <summary>
        /// Get collection of categories
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetCategories()
        {
            return _categoryCollection;
        }

        /// <summary>
        /// Load file and add items to collections
        /// </summary>
        public static void LoadFile()
        {
            if (!File.Exists(FileName)) return;

            var file = XmlSerializationHelper.Load<FileManager>(FileName);

            _dishCollection = GetItemsFromFile(file.DishCollection, _dishCollection, new DishComparer());
            _categoryCollection = GetItemsFromFile(file.CategoryCollection, _categoryCollection, new CategoryComparer());
        }

        /// <summary>
        /// Add item from source collection to target collection and remove duplicate items
        /// </summary>
        /// <typeparam name="T">Type of objects</typeparam>
        /// <param name="sourceCollection">Input collection. Get it from file</param>
        /// <param name="outputCollection">Output collection. Send that to UI</param>
        /// <param name="compararer">Class which used to compare objects</param>
        /// <returns></returns>
        private static List<T> GetItemsFromFile<T>(List<T> sourceCollection, List<T> outputCollection, IEqualityComparer<T> compararer)
        {
            outputCollection.AddRange(sourceCollection);

            return outputCollection.Distinct(compararer).ToList();
        }

        /// <summary>
        /// Serialize input collections and save it to file
        /// </summary>
        /// <param name="dishCollection">Collection of dish items</param>
        /// <param name="categoryCollection">Collection of category items</param>
        public static void SaveFile(List<Dish> dishCollection, List<Category> categoryCollection)
        {
            var fileManager = new FileManager(dishCollection, categoryCollection);

            XmlSerializationHelper.Save(fileManager, FileName);
        }

        /// <summary>
        /// Overloaded function of load file. Use for append user file to solution
        /// </summary>
        /// <param name="fileName">Path of the user file</param>
        public static void LoadFile(string fileName)
        {
            if (!File.Exists(fileName)) return;

            var file = XmlSerializationHelper.Load<FileManager>(fileName);

            _dishCollection = GetItemsFromFile(file.DishCollection, _dishCollection, new DishComparer());
            _categoryCollection = GetItemsFromFile(file.CategoryCollection, _categoryCollection, new CategoryComparer());
        }

        #endregion

    }
}
