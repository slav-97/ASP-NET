using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreApp.Models.StoreModels;
using System.Data.Entity;

namespace StoreApp.Models.DataBaseModels
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Features> Features { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<ShopOrder> ShopOrders { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        

    }
}