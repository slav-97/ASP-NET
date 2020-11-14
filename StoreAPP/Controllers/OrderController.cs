using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreApp.Models.ViewModels;
using StoreApp.Models.WebUI;
using StoreApp.Models.StoreModels;
using StoreApp.Models.DataBaseModels;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {

        private OrderViewModel orderViewModel = new OrderViewModel();
        private StoreContext storeContext = new StoreContext();

        public ActionResult Index()
        {
            orderViewModel.Cart = GetCart();

            return View(orderViewModel);
        }

        public ActionResult GetOrder(ShopOrder order)
        {
            //order.TotalPrice = double.Parse(GetCart().ComputeTotalValue().ToString());
            //order.OrderDate = DateTime.Now;
            
            try
            {
                storeContext.ShopOrders.Add(order);
                storeContext.SaveChanges();
                ShopOrder currentOrder = storeContext.ShopOrders.ToList().Last();
                foreach (CartLine cartLine in GetCart().Lines)
                {
                    storeContext.Baskets.Add(new Basket
                    {
                        ProductId = cartLine.Product.Id,
                        ShopOrderId = currentOrder.Id
                    });
                }
                storeContext.SaveChanges();
                return View(currentOrder);
            }
            catch {
                return View("ErrorMessage");
            }
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