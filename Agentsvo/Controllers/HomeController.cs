using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agentsvo.Models;

namespace Agentsvo.Controllers
{
    public class HomeController : Controller
    {
        PhoneContactContext phoneContactContext = new PhoneContactContext();

        public ActionResult AddNewContactUsingWebApi()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<PhoneContact> phoneContacts = phoneContactContext.phoneContacts;
            ViewBag.Contacts = phoneContacts;
            ViewBag.message = TempData["message"];
            return View();
        }
        [HttpPost]
        public ActionResult Index(int contactId)
        {
            IEnumerable<PhoneContact> phoneContacts = phoneContactContext.phoneContacts;
            ViewBag.Contacts = phoneContacts;
            try
            {
                PhoneContact selectedContact = phoneContactContext.phoneContacts.Find(contactId);
                phoneContactContext.phoneContacts.Remove(selectedContact);
                phoneContactContext.SaveChanges();
                return View();
            }
            catch (Exception exp)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddNewContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewContact(PhoneContact contact)
        {
            try
            {
                phoneContactContext.phoneContacts.Add(contact);
                phoneContactContext.SaveChanges();
                return View("JoinedNewContact", contact);
            }
            catch (Exception exp)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UpdateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateContact(PhoneContact contact)
        {
            try
            {
                PhoneContact selectedContact = phoneContactContext.phoneContacts.Find(contact.Id);
                if (selectedContact == null)
                {
                    ViewBag.message = "No suche user";
                }
                else
                {
                    ViewBag.message = "Ok";
                    selectedContact.Id = contact.Id;
                    selectedContact.Name = contact.Name;
                    selectedContact.Surname = contact.Surname;
                    selectedContact.BirthDay = contact.BirthDay;
                    selectedContact.Usluga = contact.Usluga;
                    selectedContact.PhoneNumber = contact.PhoneNumber;
                    phoneContactContext.SaveChanges();
                }
                return View();
            }
            catch (Exception exp)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult SearchContact()
        {
            return View();
        }
        
        public ActionResult SearchContact(int id)
        {
            IEnumerable<PhoneContact> phoneContacts = phoneContactContext.phoneContacts;
            ViewBag.Contacts = phoneContacts;
            try
            {
                PhoneContact searchContact = phoneContactContext.phoneContacts.Find(id);
    
                return View();
            }
            catch (Exception exp)
            {
                return View();
            }
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Details(int contactId)
        {
            PhoneContact c = phoneContactContext.phoneContacts.FirstOrDefault(com => com.Id == contactId);
            if (c != null)
                return PartialView(c);
            return HttpNotFound();
        }
        [HttpGet]
        public ActionResult DeleteContact()
        {
            PhoneContact contactForDelete = phoneContactContext.phoneContacts.Find(int.Parse(Request.QueryString["id"]));
            if (contactForDelete == null)
            {
               TempData["message"]= "No suche user";
            }
            else
            {

                phoneContactContext.phoneContacts.Remove(contactForDelete);
                phoneContactContext.SaveChanges();
                TempData["message"] = "Ok";
            }
            return Redirect("/home/index");
        }
    }
}