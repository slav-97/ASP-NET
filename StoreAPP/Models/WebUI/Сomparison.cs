using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreApp.Models.StoreModels;

namespace StoreApp.Models.WebUI
{
    public class Сomparison
    {
        private List<СomparisonLine> lineCollection = new List<СomparisonLine>();

        public void AddItem(Product product, Features features)
        {
            СomparisonLine line = lineCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new СomparisonLine
                {
                    Product = product,
                    Features = features
                });
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }

        public IEnumerable<СomparisonLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class СomparisonLine
    {
        public Product Product { get; set; }
        public Features Features { get; set; }
    }
}