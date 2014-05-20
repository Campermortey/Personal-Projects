using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.Models.Interfaces;

namespace OperationsLayer.BLL.Level2Numbers.TemperatureConverters
{
    public class CelsiusToKelvinConversion : IUnitConverter
    {
        public decimal Convert(decimal fromValue)
        {
            return (fromValue + (decimal)273.15);
        }
    }
}
