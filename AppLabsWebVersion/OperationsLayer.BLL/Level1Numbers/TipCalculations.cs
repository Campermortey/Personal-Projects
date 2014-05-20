using AppLabs.Models.Level1Numbers;


namespace OperationsLayer.BLL.Level1Numbers
{
    public class TipCalculations
    {
        public TipCalculatorResponse Calculate(TipCalculatorRequest request)
        {
            var response = new TipCalculatorResponse();
            response.DollarValue = request.DollarValue;
            response.TipPercent = request.TipPercentage;
            response.DollarValue = request.DollarValue;
            response.TipPercent = request.TipPercentage / 100;
            response.Tip = response.DollarValue * response.TipPercent;
            response.Total = response.Tip + response.DollarValue;

            return response;

        }
    }
}
