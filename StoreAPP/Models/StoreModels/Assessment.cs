using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApp.Models.StoreModels
{
    public class Assessment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public int Evaluation { get; set; }
    }
}
