using AppLabs.Models.Interfaces;

namespace OperationsLayer.BLL.Level2Numbers.CurrencyConverter
{
    public class EuroToDollarConverter : IUnitConverter
    {
        public decimal Convert(decimal fromValue)
        {
            return fromValue*(decimal) 1.37;
        }
    }
}