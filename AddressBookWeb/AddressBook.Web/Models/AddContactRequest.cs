using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AddressBook.DTOs;

namespace AddressBook.Web.Models
{
    public class AddContactRequest
    {
        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Contact CreateContact()
        {
            return new Contact {FirstName = FirstName, LastName = LastName, Email = Email, Phone = Phone};
        }
    }
}