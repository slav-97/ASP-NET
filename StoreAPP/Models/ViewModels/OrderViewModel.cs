using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreApp.Models.StoreModels;
using StoreApp.Models.WebUI;

namespace StoreApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public ShopOrder ShopOrder { get; set; }
        public Cart Cart { get; set; }
    }
}