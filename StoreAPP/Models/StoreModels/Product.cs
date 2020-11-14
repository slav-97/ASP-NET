using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApp.Models.StoreModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Manufacturer { get; set; }
        public string ImageUrl { get; set; }
        public int FeaturesId { get; set; }
    }
}