using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.Models.Level1Numbers;

namespace OperationsLayer.BLL.Level1Numbers
{
    public class FlooringCalculatorWork
    {

        public FlooringCalculatorResponse CalculateFloor(FlooringCalculatorRequest request)
        {
            FlooringCalculatorResponse response = new FlooringCalculatorResponse();
            response.Area = request.Length*request.Width;
            response.TotalCost = request.Cost*response.Area;

            return response;
        }
    }
}
