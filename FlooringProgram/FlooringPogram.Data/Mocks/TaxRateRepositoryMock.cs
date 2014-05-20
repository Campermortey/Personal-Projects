using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringPogram.Data.Mocks
{
    /// <summary>
    /// Creates a repository that stores Tax Rate data to test
    /// </summary>
    public class TaxRateRepositoryMock : ITaxRateRepository
    {
        public List<TaxRate> GetAllTaxRates()
        {
            //returns a list of TaxRate
            return new List<TaxRate>()
            {
                //creates new TaxRate objects
                new TaxRate() {State = "OH", TaxPercent = 0.10M},
                new TaxRate() {State = "PA", TaxPercent = 0.29M}
            };

        } 
    }
}
