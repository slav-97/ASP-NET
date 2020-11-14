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
    public class CartController : Controller
    {

        private StoreContext storeContext = new StoreContext();

        public ViewResult Index(string returnUrl)
        {
            return View(new ProductsViewModel
            {
                Cart = GetCart()
            });
        }


        public ActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = storeContext.Products.
                FirstOrDefault(p => p.Id == productId);


            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return Redirect( returnUrl );
        }

        public ActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = storeContext.Products
                .FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return Redirect(returnUrl);
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}