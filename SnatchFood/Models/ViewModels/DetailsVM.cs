using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnatchFood.Models.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM()
        {
            Menu = new Menu();
        }

        public Menu Menu { get; set; }
    }
}
