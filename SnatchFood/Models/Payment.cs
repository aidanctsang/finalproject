using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SnatchFood.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public List<Orders> Orders { get; set; }
        public decimal Amount { get; set; }

        public DateTime DatePaid { get; set; }

    }
}
