using System.Collections.Generic;
using System.IO;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringPogram.Data.Loaders
{
    public class TaxLoader : ITaxRateRepository
    {
        /// <summary>
        /// Load taxes into a List of TaxRate
        /// </summary>
        /// <returns>List of TaxRate</returns>
        public List<TaxRate> GetAllTaxRates()
        {
            //directly set the filename to the data folder
            string fileName = @"Data\TaxRates.txt";

            //if it exists, read all lives, convert CSV to order then store in a list of TaxRate. Return that list
            if (File.Exists(fileName))
            {
                string[] taxesAsStrings = File.ReadAllLines(fileName);
                List<TaxRate> output = ConvertCSVToOrder(taxesAsStrings);

                return output;
            }

            return new List<TaxRate>();
        }

        private List<TaxRate> ConvertCSVToOrder(string[] taxesAsStrings)
        {
            //create a new Orders List
            List<TaxRate> output = new List<TaxRate>();

            for (int i = 1; i < taxesAsStrings.Length; i++)
            {
                if (!string.IsNullOrEmpty(taxesAsStrings[i]))
                {
                    //set up a new array that splits the row based on ","
                    string[] newRow = taxesAsStrings[i].Split(',');

                    TaxRate tax = new TaxRate();

                    tax.State = newRow[0];
                    tax.TaxPercent = decimal.Parse(newRow[1]);

                    //Add this to the Tax object
                    output.Add(tax);
                }
            }
            return output;
        }
      
    }
}
