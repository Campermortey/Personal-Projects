using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabsWebVersion.Models.Level2Numbers
{
    public class ChangeReturnValidation
    {
        [Required(ErrorMessage = "Please enter a valid cost")]
        public decimal? Cost { get; set; }

        [Required(ErrorMessage = "Please enter the cash you are paying")]
        public decimal? EnteredCash { get; set; }

        [Required(ErrorMessage = "Please select a product")]
        public string Product { get; set; }
    }
}