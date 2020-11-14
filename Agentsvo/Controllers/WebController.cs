using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Agentsvo.Models;

namespace Agentsvo.Controllers
{
    public class WebController : ApiController
    {
        private PhoneContactContext phoneContactContext = new PhoneContactContext();

        [HttpGet]
        public IEnumerable<PhoneContact> Get()
        {
            return phoneContactContext.phoneContacts;
        }
        [HttpGet]
        public PhoneContact Get(int id)
        {
            return phoneContactContext.phoneContacts.Find(id);
        }
        [HttpDelete]
        public string Delete(int id)
        {
            PhoneContact contactForDelete = phoneContactContext.phoneContacts.Find(id);
            if (contactForDelete==null)
            {
                return ("No suche user");
            }
            else
            {

                phoneContactContext.phoneContacts.Remove(contactForDelete);
                phoneContactContext.SaveChanges();
                return ("Ok");
            }
        }
        [HttpPost]
        public PhoneContact Post(PhoneContact contact)
        {
            phoneContactContext.phoneContacts.Add(contact);
            phoneContactContext.SaveChanges();
            return contact;
        }
        [HttpPut]
        public void Put(PhoneContact contact)
        {
            PhoneContact selectedContact = phoneContactContext.phoneContacts.Find(contact.Id);
            selectedContact.Id = contact.Id;
            selectedContact.Name = contact.Name;
            selectedContact.Surname = contact.Surname;
            selectedContact.BirthDay = contact.BirthDay;
            selectedContact.Usluga = contact.Usluga;
            selectedContact.PhoneNumber = contact.PhoneNumber;
            phoneContactContext.SaveChanges();
        }
    }
}