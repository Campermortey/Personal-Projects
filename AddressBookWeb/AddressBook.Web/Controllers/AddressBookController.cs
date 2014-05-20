using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.DTOs;
using AddressBook.DTOs.Interfaces;
using AddressBook.Web.Models;

namespace AddressBook.Web.Controllers
{
    public class AddressBookController : Controller
    {
        private readonly IContactRepository _repository;

        public AddressBookController(IContactRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /AddressBook/
        public ActionResult Index()
        {
            var contacts = _repository.GetAll();
            return View(contacts);
        }

        public ActionResult Add()
        {
            var model = new AddContactRequest();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddContactRequest model)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(model.CreateContact());
                TempData["Message"] = "Contact created!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var contact = _repository.GetById(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult Delete(Contact contactToDelete)
        {
            _repository.Delete(contactToDelete.Id);
            TempData["Message"] = "Contact deleted!";
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            var model = new SearchRequest();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(SearchRequest model)
        {
            if (ModelState.IsValid)
            {
                model.SearchResults = _repository.Search(model.SearchText);
            }
            
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var contact = _repository.GetById(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(EditContactRequest model)
        {
            var x = model.EditContact(model);
            if (ModelState.IsValid)
            {
                
                _repository.Edit(x);
                TempData["Message"] = "Contact Edited!";
                return RedirectToAction("Index");
            }
            return View(x);
        }
	}
}