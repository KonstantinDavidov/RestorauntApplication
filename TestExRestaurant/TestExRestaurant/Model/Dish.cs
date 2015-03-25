using System;
using System.Threading;
using System.Xml.Serialization;
using TestExRestaurant.Utils;

namespace TestExRestaurant.Model
{
    /// <summary>
    /// Class which represents the product
    /// </summary>
    public class Dish : PropertyChangedBase, IEquatable<Dish>
    {
        #region Variables

        private string _name;

        private Category _category;

        private decimal _price;

        #endregion

        #region Properties

        /// <summary>
        /// Name of the object
        /// </summary>
        [XmlElement("Name")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Represents a category of the item
        /// </summary>
        [XmlElement("CategoryName")]
        public Category Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }

        /// <summary>
        /// Price of the dish item
        /// </summary>
        [XmlElement("Price")]
        public decimal Price 
        { 
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            } 
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Dish x, Dish y)
        { 
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Name == y.Name && x.Name == y.Name;
        }

        public int GetHashCode(Dish product)
        {
            if (ReferenceEquals(product, null)) return 0;

            int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();

            return hashProductName;
        }

        public bool Equals(Dish other)
        {
            if (ReferenceEquals(other, this)) return true;
            if (Name == null) return false;
            return Name.Equals(other.Name);
        }

        #endregion
    }
}
