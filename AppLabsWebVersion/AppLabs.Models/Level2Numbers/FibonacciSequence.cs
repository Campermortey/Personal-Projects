using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.Models.Level2Numbers
{
    public class FibonacciSequence
    {
        public int Term { get; set; }
        public List<int> Sequence { get; set; }

        public FibonacciSequence()
        {
            Sequence = new List<int>();
        }
    }
}
