using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SnatchFood.Models.ViewModels
{
    public class CartUserVM
    {
        [Key]
        public int Id { get; set; }

        public List<CartItem> CartList { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid format.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }


    }
}
