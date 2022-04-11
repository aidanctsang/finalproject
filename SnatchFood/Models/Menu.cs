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

        [Display(Name = "Menu Name")]
        [Required(ErrorMessage = "Required.")]
        public string MenuName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue)]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Required")]
        public virtual Restaurants Restaurants { get; set; }

        public int? RestoId { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
