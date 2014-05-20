using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.Models.Level2Numbers;

namespace OperationsLayer.BLL.Level2Numbers
{
    public class PrimeNumberCalculation
    {
        PrimeNumbers _prime = new PrimeNumbers();

        public int Calculation(int number)
        {
            while (true)
            {
                bool isPrime = true;
                //increment the number by 1 each time
                number = number + 1;

                int numberSquared = (int)Math.Round(Math.Sqrt(number));

                //start at 2 and increment by 1 until it gets to the squared number
                for (int i = 2; i <= numberSquared; i++)
                {
                    //how do I check all i's?
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    return number;
            }
            
        }
    }
}
