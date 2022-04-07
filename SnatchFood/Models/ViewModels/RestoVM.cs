using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnatchFood.Models.ViewModels
{
    public class RestoVM
    {
        public IEnumerable<Restaurants> RestaurantList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
    }
}
