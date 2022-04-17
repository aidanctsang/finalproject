using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SnatchFood.Models
{
    public class CartItem
    {
        [Key]
        public int CartId { get; set; }

        public string MenuName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Required.")]
        public int Qty { get; set; }

        [Display(Name = "Order Status")]
        public string Status { get; set; }
    }
}
