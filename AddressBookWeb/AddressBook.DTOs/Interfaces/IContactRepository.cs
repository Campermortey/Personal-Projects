using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DTOs.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        List<Contact> Search(string lastName);
        void Add(Contact contact);
        void Delete(int id);
        void Edit(Contact contact);
    }
}
