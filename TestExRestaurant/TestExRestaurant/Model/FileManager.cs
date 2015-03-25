using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestExRestaurant.Model
{
    /// <summary>
    /// Represets a class of output serialized File
    /// </summary>
    [XmlRoot("Menu")]
    public class FileManager
    {
        #region Properties

        /// <summary>
        /// List of dishes
        /// </summary>
        [XmlArray("Dishes")]
        [XmlArrayItem("Dish", typeof(Dish))]
        public List<Dish> DishCollection { get; set; }
 
        /// <summary>
        /// List of categories
        /// </summary>
        [XmlArray("Categories")]
        [XmlArrayItem("Category", typeof(Category))]
        public List<Category> CategoryCollection { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public FileManager()
        {
        }

        /// <summary>
        /// Contructor with parameters
        /// </summary>
        /// <param name="dishCollection">List of dishes which want to save</param>
        /// <param name="categoryCollection">List of categories which want to save</param>
        public FileManager(List<Dish> dishCollection, List<Category> categoryCollection)
        {
            DishCollection = dishCollection;
            CategoryCollection = categoryCollection;
        }

        #endregion
    }
}
