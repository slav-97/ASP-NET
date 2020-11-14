using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreApp.Models.StoreModels;
using StoreApp.Models.WebUI;

namespace StoreApp.Models.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Features> Features { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public IEnumerable<Assessment> Assessments { get; set; }

        public ProductsFilter ProductsFilter { get; set; }

        public Cart Cart { get; set; }

        public Сomparison Сomparison { get; set; }


        public ProductsViewModel()
        {
            ProductsFilter = new ProductsFilter();
        }
    }
}