using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.Models.Level2Numbers;

namespace OperationsLayer.BLL.Level2Numbers
{
    public class FibonacciSequenceOperations
    {
        
        FibonacciSequence request = new FibonacciSequence();
        public FibonacciSequence CalculateSequence(int term)
        {
            
            request.Sequence.Add(0);
            request.Sequence.Add(1);

            for (int i = 0; i <= term -2; i++)
            {
               request.Sequence.Add(request.Sequence.ElementAt(i) + request.Sequence.ElementAt(i +1));
            }

            return request;
        }
    }
}
