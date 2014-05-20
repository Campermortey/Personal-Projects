using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.Models.Interfaces;

namespace OperationsLayer.BLL.Level2Numbers.CurrencyConverter
{
    public class DollarToEuroConverter : IUnitConverter
    {

        public decimal Convert(decimal fromValue)
        {
            return fromValue*(decimal).73;
        }
    }
}
