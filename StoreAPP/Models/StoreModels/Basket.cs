using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApp.Models.StoreModels
{
    public class Basket
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShopOrderId { get; set; }
    }
}