using AppLabs.Models.Interfaces;

namespace OperationsLayer.BLL.Level2Numbers.MassConverter
{
    public class CupsToOuncesConverter : IUnitConverter
    {
        public decimal Convert(decimal fromValue)
        {
            return fromValue*8;
        }
    }
}