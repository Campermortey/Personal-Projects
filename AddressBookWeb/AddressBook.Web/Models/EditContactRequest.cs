using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AddressBook.DTOs;

namespace AddressBook.Web.Models
{
    public class EditContactRequest
    {
        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Id { get; set; }

        

        public Contact EditContact(EditContactRequest c)
        {
            return new Contact { FirstName = c.FirstName, LastName = c.LastName, Email = c.Email, Phone = c.Phone, Id = c.Id};
        }
    }
}