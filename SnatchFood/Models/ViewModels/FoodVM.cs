using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnatchFood.Models.ViewModels
{
    public class FoodVM
    {
        public List<Menu> MenuList { get; set; }

        public List<Restaurants> RestaurantList{ get; set; }
        
    }
}
