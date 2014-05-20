using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppLabsWebVersion.Models.Level1Numbers
{
    public class LeapYearsValidation
    {
        [Required(ErrorMessage = "Enter the Beginning Year")]
        public int? BeginningDate { get; set; }

        [Required(ErrorMessage = "Enter the Ending Year")]
        public int? EndingDate { get; set; }
    }
}