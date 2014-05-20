using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.DTOs;
using AddressBook.DTOs.Interfaces;

namespace AddressBook.Data.InMemoryRepositories
{
    public class InMemoryContactRepository : IContactRepository
    {
        private static List<Contact> _contacts = new List<Contact>(); 

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public List<Contact> Search(string lastName)
        {
            var results = _contacts.Where(c => c.LastName.Contains(lastName));
            return results.ToList();
        }

        public void Add(Contact contact)
        {
            if (_contacts.Any())
                contact.Id = _contacts.Max(c => c.Id) + 1;
            else
                contact.Id = 1;

            _contacts.Add(contact);
        }

        public void Delete(int id)
        {
            _contacts.RemoveAll(c => c.Id == id);
        }

        public void Edit(Contact contact)
        {
            Delete(contact.Id);
            _contacts.Add(contact);
        }


        public Contact GetById(int id)
        {
            return _contacts.First(c => c.Id == id);
        }
    }
}
