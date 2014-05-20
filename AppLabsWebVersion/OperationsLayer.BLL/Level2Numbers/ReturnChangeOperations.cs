using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.Models.Level2Numbers;

namespace OperationsLayer.BLL.Level2Numbers
{
    public class ReturnChangeOperations
    {
        ReturnChangeResponse response = new ReturnChangeResponse();

        public ReturnChangeResponse CalculateDifferent(ReturnChangeRequest request)
        {
            response.DifferenceChange = decimal.Subtract(request.EnteredCash, request.Cost);
            return response;
        }

        public ReturnChangeResponse CalculateChange(ReturnChangeResponse response)
        {
            //take decimal and muiltipy it by 100. Store it to itself to become the default value
            response.DifferenceChange *= 100;

            int centsAsInt = (int) response.DifferenceChange;

            response.Quarters = centsAsInt/25;
            centsAsInt -= response.Quarters*25;

            response.Dimes = centsAsInt/10;
            centsAsInt -= response.Dimes*10;

            response.Nickles = centsAsInt/5;
            centsAsInt -= response.Nickles*5;

            response.Pennies = centsAsInt/1;

            return response;
        }
    }
}
