using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreApp.Models.StoreModels;
using StoreApp.Models.DataBaseModels;
using StoreApp.Models.ViewModels;
using StoreApp.Models.WebUI;

namespace StoreApp.Controllers
{
    public class СomparisonController : Controller
    {
        private StoreContext storeContext = new StoreContext();

        public ActionResult Index()
        {
            return View(new ProductsViewModel
            {
                Сomparison = GetСomparison()
            });
        }

        public ActionResult AddToСomparison(int productId, string returnUrl)
        {
            Product product = storeContext.Products.
                FirstOrDefault(p => p.Id == productId);

            List<Features> featuresList = storeContext.Features.ToList();


            if (product != null)
            {
                Features features = featuresList.Find(x => x.Id == product.FeaturesId);
                GetСomparison().AddItem(product, features);
            }

            return Redirect(returnUrl);
        }

        public ActionResult RemoveFromComparison(int productId, string returnUrl)
        {
            Product product = storeContext.Products
                .FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                GetСomparison().RemoveLine(product);
            }
            return Redirect(returnUrl);
        }

        public Сomparison GetСomparison()
        {
            Сomparison comparison = (Сomparison)Session["Сomparison"];
            if (comparison == null)
            {
                comparison = new Сomparison();
                Session["Сomparison"] = comparison;
            }
            return comparison;
        }
    }
}