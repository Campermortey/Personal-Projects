using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Operations
{
    public class TaxRateManager
    {
        private ITaxRateRepository _myTaxRateRepository;

        //passes in a TaxRate repository that specifies if it is going to use Test mode or Prod mode
        public TaxRateManager(ITaxRateRepository taxRateRepository)
        {
            _myTaxRateRepository = taxRateRepository;
        }

        //Gets a list of all the tax rates in the text files
        public List<TaxRate> GetAllTaxRates()
        {
            return _myTaxRateRepository.GetAllTaxRates();
        }

        //Get a TaxRate based on the state entered
        public TaxRate GetTaxRateFor(string state)
        {
            var allRates = _myTaxRateRepository.GetAllTaxRates();
            return allRates.FirstOrDefault(r => r.State == state);
        }

    }
}
