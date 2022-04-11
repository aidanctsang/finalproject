using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnatchFood.Models.ViewModels
{
    public class RestoVM
    {
        public List<Restaurants> RestaurantList { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
