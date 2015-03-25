using System;
using System.Collections.Generic;
using System.Linq;
using TestExRestaurant.Model;

namespace TestExRestaurant.Utils
{
    /// <summary>
    /// Implemets comparer to compare category items
    /// </summary>
    class CategoryComparer : IEqualityComparer<Category>
    {
        public bool Equals(Category x, Category y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Category obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
