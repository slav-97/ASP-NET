using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreApp.Models.StoreModels;
using StoreApp.Models.WebUI;

namespace StoreApp.Models.ViewModels
{
    public class ProductInfoViewModel
    {
        public Product Product { get; set; }
        public Features Features { get; set; }
        public Cart Cart { get; set; }
        public Сomparison Сomparison { get; set; }

        public IEnumerable<Assessment> Assessments { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}