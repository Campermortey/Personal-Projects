using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AddressBook.DTOs;

namespace AddressBook.Web.Models
{
    public class SearchRequest
    {
        [Required(ErrorMessage = "Please enter part of a last name")]
        public string SearchText { get; set; }
        public List<Contact> SearchResults { get; set; } 
    }
}