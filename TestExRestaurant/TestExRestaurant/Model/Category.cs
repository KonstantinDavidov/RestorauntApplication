using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Xml.Serialization;
using TestExRestaurant.Utils;

namespace TestExRestaurant.Model
{
    /// <summary>
    /// Class of Dish category
    /// </summary>
    public class Category : PropertyChangedBase
    {
        #region Variables

        private string _name;

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

        #endregion
    }
}
