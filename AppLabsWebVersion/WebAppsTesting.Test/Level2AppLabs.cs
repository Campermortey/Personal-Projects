using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppLabs.Models.Level2Numbers;
using NUnit.Framework;
using OperationsLayer.BLL.Level2Numbers;

namespace WebAppsTesting.Test
{
    [TestFixture]
    public class Level2AppLabs
    {
        [Test]
        public void FibonacciSequenceTest()
        {
            FibonacciSequence request = new FibonacciSequence();
            FibonacciSequenceOperations op = new FibonacciSequenceOperations();

            request.Term = 6;

            List<int> expected = new List<int>() {0, 1, 1, 2, 3, 5};

            Assert.AreEqual(expected, op.CalculateSequence(request.Term));

        }

        [Test]

        public void PrimeNumberTest()
        {
            PrimeNumberCalculation calc = new PrimeNumberCalculation();
            PrimeNumbers prime = new PrimeNumbers();

            prime.UserNumber = 7;

            Assert.AreEqual(11, calc.Calculation(prime.UserNumber));
        }

    }
}
