using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Agentsvo.Models
{
    public class PhoneContactsDbInitializer : DropCreateDatabaseAlways<PhoneContactContext>
    {
        protected override void Seed(PhoneContactContext db)
        {
            db.phoneContacts.Add(new PhoneContact { Id = 1, Name = "Иван", Surname = "Иванов", BirthDay = DateTime.Now, Usluga = "Продажа", PhoneNumber = "375 (33) 777-55-33" });
            db.phoneContacts.Add(new PhoneContact { Id = 2, Name = "Андрей", Surname = "Котов", BirthDay = DateTime.Now, Usluga = "Продажа", PhoneNumber = "375 (33) 888-55-33" });
            db.phoneContacts.Add(new PhoneContact { Id = 3, Name = "Алексей", Surname = "Иванов", BirthDay = DateTime.Now, Usluga = "Аренда", PhoneNumber = "375 (33) 999-55-33" });
            db.phoneContacts.Add(new PhoneContact { Id = 4, Name = "Иван", Surname = "Белов", BirthDay = DateTime.Now, Usluga = "Продажа", PhoneNumber = "375 (33) 555-55-33" });
            db.phoneContacts.Add(new PhoneContact { Id = 5, Name = "Влад", Surname = "Иванов", BirthDay = DateTime.Now, Usluga = "Аренда", PhoneNumber = "375 (33) 333-55-33" });
        }
    }
}