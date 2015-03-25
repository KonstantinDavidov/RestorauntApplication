using System.Collections.Generic;
using TestExRestaurant.Model;

namespace TestExRestaurant.Utils
{
    /// <summary>
    /// Implemets comparer to compare dish items
    /// </summary>
    public class DishComparer : IEqualityComparer<Dish>
    {
        public bool Equals(Dish x, Dish y)
        {
            return 
                x.Name == y.Name &&
                x.Price == y.Price &&
                x.Category.Name == y.Category.Name;
        }

        public int GetHashCode(Dish obj)
        {
            return 
                obj.Name.GetHashCode() ^
                obj.Price.GetHashCode() ^
                obj.Category.Name.GetHashCode();
        }
    }
}
