using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabsWebVersion.Models.Level1Numbers
{
    public class TipCalculation
    {
        [Required(ErrorMessage = "Enter the meal amount")]
        public decimal? DollarValue { get; set; }

        [Required(ErrorMessage = "Enter the tip percent")]
        [Range(0, 100)]
        public decimal? TipPercentage { get; set; }
    }
}