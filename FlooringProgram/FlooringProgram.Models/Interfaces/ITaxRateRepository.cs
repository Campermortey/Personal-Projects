using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;

namespace FlooringProgram.Models.Interfaces
{
    /// <summary>
    /// Create a TaxRateRepository that returns TaxRates
    /// </summary>
    public interface ITaxRateRepository
    {
         List<TaxRate> GetAllTaxRates();
    }
}
