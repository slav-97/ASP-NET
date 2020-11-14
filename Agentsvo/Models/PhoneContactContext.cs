using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Agentsvo.Models
{
    public class PhoneContactContext : DbContext
    {
        public DbSet<PhoneContact> phoneContacts { get; set; }
    }
}