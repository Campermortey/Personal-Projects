using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.Models.Level1Numbers
{
    public class LeapYearResponse
    {
        public int BeginningDate { get; set; }
        public int EndingDate { get; set; }
        public List<int> Dates { get; set; }
    }
}
