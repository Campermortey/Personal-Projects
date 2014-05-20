using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.Models.Level2Numbers
{
    public class ReturnChangeResponse
    {
        public decimal DifferenceChange { get; set; }
        public int Quarters { get; set; }
        public int Dimes { get; set; }
        public int Nickles { get; set; }
        public int Pennies { get; set; }
    }
}
