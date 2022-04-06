using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SnatchFood.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        public List<Restaurants> Restaurants { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Menu Name")]
        public string MenuName { get; set; }

        //Image
        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Qty { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
