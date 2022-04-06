using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SnatchFood.Models
{
    public class Restaurants
    {
        [Key]
        public int RestaurantId { get; set; }

        [Display(Name = "Restaurant Name")]
        [Required(ErrorMessage = "Required.")]
        public string RestaurantName { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Required.")]
        public virtual Category Category { get; set; }

        public int? CatId { get; set; }
    }

    public class Category {
        [Key]
        public int CatId { get; set; }

        public string Name { get; set; }
    } 
}
