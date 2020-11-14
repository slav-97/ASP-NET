using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApp.Models.StoreModels
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; }
        public string NickNameAuthor { get; set; }
    }
}