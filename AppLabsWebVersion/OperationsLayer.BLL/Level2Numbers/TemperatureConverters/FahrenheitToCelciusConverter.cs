using AppLabs.Models.Interfaces;

namespace OperationsLayer.BLL.Level2Numbers.TemperatureConverters
{
    public class FahrenheitToCelciusConverter : IUnitConverter
    {
        public decimal Convert(decimal fromValue)
        {
            return ((fromValue - 32) * 5) / 9;
        }
    }
}
