using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabsWebVersion.Models.Level1Numbers
{
    public class FlooringCalculatorValidation
    {
        [Required(ErrorMessage = "Please enter a valid number")]
        public int? Width { get; set; }
        [Required(ErrorMessage = "Please enter a valid number")]
        public int? Length { get; set; }
        [Required(ErrorMessage = "Please enter a valid cost")]
        public decimal? Cost { get; set; }
    }
}