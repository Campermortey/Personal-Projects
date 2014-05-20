using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.Models.Level1Numbers;

namespace OperationsLayer.BLL.Level1Numbers
{
    public class LeapYearCalculation
    {
        
        private List<int> Dates = new List<int> {};
        

        public LeapYearResponse TotalDates(int beginningDate, int endingDate)
        {
            LeapYearResponse response = new LeapYearResponse();
            //search through the dates starting at the beginning date until the ending date to see if there are any leap years
            for (int i = beginningDate; i < endingDate; i++)
            {

                if ((i%4 == 0 && i%100 != 0) || (i%100 == 0 && i%400 == 0))
                {

                    Dates.Add(i);
                }

            }

            //set the response fields equal to the request fields
            response.BeginningDate = beginningDate;
            response.EndingDate = endingDate;
            response.Dates = Dates;
            return response;
        }
    }
}
