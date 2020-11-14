using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreApp.Models.StoreModels
{
    public class ShopOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        public double TotalPrice { get; set; }
    }
}