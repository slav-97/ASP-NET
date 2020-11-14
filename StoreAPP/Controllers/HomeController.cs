using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreApp.Models.DataBaseModels;
using StoreApp.Models.ViewModels;
using StoreApp.Models.StoreModels;
using StoreApp.Models.WebUI;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        private ProductsViewModel productsViewModel = new ProductsViewModel();
        private StoreContext storeContext = new StoreContext();
        private ProductInfoViewModel productInfoViewModel = new ProductInfoViewModel();

        private int pageSize = 10;
        private PageInfo pageInfo = new PageInfo();

        public ActionResult Index(int page = 1)
        {
            productsViewModel.Assessments = storeContext.Assessments;
            productsViewModel.Reviews = storeContext.Reviews;
            productInfoViewModel.Reviews = storeContext.Reviews;
            productsViewModel.Features = storeContext.Features;
            productInfoViewModel.Assessments = storeContext.Assessments;
            productsViewModel.Cart = GetCart();
            productsViewModel.Сomparison = GetСomparison();


            pageInfo.CurrentPage = 1;
            pageInfo.ItemsPerPage = pageSize;
            pageInfo.TotalItems = storeContext.Products.Count();
            ViewBag.PageInfo = pageInfo;
            productsViewModel.Products = storeContext.Products.OrderBy(x =>x.Id).Skip((page - 1) * pageSize).Take(pageSize);
            return View(productsViewModel);
        }



        public ActionResult Product(int Id)
        {
            productInfoViewModel.Assessments = storeContext.Assessments;
            productInfoViewModel.Cart = GetCart();
            productInfoViewModel.Сomparison = GetСomparison();

            productInfoViewModel.Product = storeContext.Products.FirstOrDefault(x => x.Id == Id);
            productInfoViewModel.Features = storeContext.Features.
                FirstOrDefault(x => x.Id == productInfoViewModel.Product.FeaturesId);

            productInfoViewModel.Reviews = from review in storeContext.Reviews
                                           where review.ProductId == Id
                                           select review;

            return View(productInfoViewModel);
        }
        public ActionResult AddAssessment(int Id, int evaluetion,string username, string returnUrl)
        {
            if (evaluetion >= 0 && evaluetion <= 10)
            {
                storeContext.Assessments.Add(new Assessment
                {
                    Id = 0,
                    ProductId = Id,
                    Evaluation = evaluetion,
                    UserName = username
                });
                storeContext.SaveChanges();
                return Redirect(returnUrl);
            }

            return Redirect(returnUrl);
        }

        public ActionResult DeleteAssessment(int Id, string returnUrl)
        {
            List<Assessment> assessments = storeContext.Assessments.ToList();
            Assessment assessment = assessments.Find(x => x.Id == Id);

            storeContext.Assessments.Remove(assessment);
            storeContext.SaveChanges();

            return Redirect(returnUrl);
        }

        public ActionResult AddReview(int Id, string reviewText, string userName)
        {
            productInfoViewModel.Assessments = storeContext.Assessments;
            productInfoViewModel.Cart = GetCart();
            productInfoViewModel.Сomparison = GetСomparison();

            productInfoViewModel.Product = storeContext.Products.FirstOrDefault(x => x.Id == Id);
            productInfoViewModel.Features = storeContext.Features.
                FirstOrDefault(x => x.Id == productInfoViewModel.Product.FeaturesId);

            productInfoViewModel.Reviews = from review in storeContext.Reviews
                                           where review.ProductId == Id
                                           select review;

            if (storeContext.Reviews.FirstOrDefault
                (x => x.NickNameAuthor == userName && x.ProductId == Id) == null)
            {
                storeContext.Reviews
                .Add(new Review { NickNameAuthor = userName, ProductId = Id, Text = reviewText });
                storeContext.SaveChanges();
            }

            return View("Product", productInfoViewModel);
        }

        public ActionResult DeleteReview(int Id, string author) {
            productInfoViewModel.Assessments = storeContext.Assessments;
            productInfoViewModel.Cart = GetCart();
            productInfoViewModel.Сomparison = GetСomparison();

            productInfoViewModel.Product = storeContext.Products.FirstOrDefault(x => x.Id == Id);
            productInfoViewModel.Features = storeContext.Features.
                FirstOrDefault(x => x.Id == productInfoViewModel.Product.FeaturesId);

            productInfoViewModel.Reviews = from review in storeContext.Reviews
                                           where review.ProductId == Id
                                           select review;

            storeContext.Reviews.Remove
                (storeContext.Reviews.FirstOrDefault(x => x.NickNameAuthor == author && x.ProductId == Id));
            storeContext.SaveChanges();

            return View("Product", productInfoViewModel);
        }

        public ActionResult SearchData(string serchInfo = "")
        {
            productsViewModel.Assessments = storeContext.Assessments;
            productsViewModel.Reviews = storeContext.Reviews;
            productInfoViewModel.Reviews = storeContext.Reviews;
            productsViewModel.Features = storeContext.Features;
            productsViewModel.Cart = GetCart();
            productsViewModel.Сomparison = GetСomparison();

            string[] words = serchInfo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<Product> searchResult = new List<Product>();
            List<Features> featuresList = storeContext.Features.ToList();
            string strForRegular = "";
            bool getInRequltList = true;

            foreach (Product product in storeContext.Products)
            {
                Features productFeatures = featuresList.Find(x => x.Id == product.FeaturesId);
                strForRegular +=  product.Id + " " + product.Name + " " + productFeatures.MemoryType + " ";
                strForRegular += productFeatures.MemoryCapacity + " " + productFeatures.Appointment + " ";
                strForRegular += product.Manufacturer;
                foreach (string word in words)
                {
                    if (!(strForRegular.IndexOf(word) >= 0))
                    {
                        getInRequltList = false;
                        break;
                    }
                }
                if (getInRequltList)
                {
                    searchResult.Add(product);
                }
                getInRequltList = true;
                strForRegular = "";
            }
            productsViewModel.Products = searchResult;
            pageInfo.CurrentPage = 1;
            pageInfo.ItemsPerPage = pageSize;
            pageInfo.TotalItems = productsViewModel.Products.Count();
            ViewBag.PageInfo = pageInfo;
            productsViewModel.Products = productsViewModel.Products.OrderBy(x => x.Id).Skip((1 - 1) * pageSize).Take(pageSize);


            return View("Index", productsViewModel);
        }


        public ActionResult FilterDate(ProductsFilter productsFilter)
        {
            productsViewModel.Assessments = storeContext.Assessments;
            productsViewModel.Reviews = storeContext.Reviews;
            productInfoViewModel.Reviews = storeContext.Reviews;
            productsViewModel.Cart = GetCart();
            productsViewModel.Сomparison = GetСomparison();

            bool isCheckedItems = false;
            productsViewModel.Features = storeContext.Features;
            productsViewModel.Products = storeContext.Products;
            List<Features> featuresList = storeContext.Features.ToList();

            List<string> manufacturerFilter = new List<string>();
            for (int i = 0; i < productsFilter.ManufacturersList.Count; i++)
            {
                if (productsFilter.ManufacturersList[i].IsChecked)
                {
                    manufacturerFilter.Add(productsViewModel.ProductsFilter.ManufacturersList[i].Manufacturer);
                    isCheckedItems = true;
                }
            }
            if (isCheckedItems)
            {
                productsViewModel.Products = from product in productsViewModel.Products
                                             where manufacturerFilter.Contains(product.Manufacturer)
                                             select product;
                isCheckedItems = false;
            }

            List<string> memoryTypeFilter = new List<string>();
            for (int i = 0; i < productsFilter.MemoryTypeList.Count; i++)
            {
                if (productsFilter.MemoryTypeList[i].IsChecked)
                {
                    memoryTypeFilter.Add(productsViewModel.ProductsFilter.MemoryTypeList[i].MemoryType);
                    isCheckedItems = true;
                }
            }

            if (isCheckedItems)
            {
                productsViewModel.Products = from product in productsViewModel.Products
                                             where memoryTypeFilter.
                                             Contains(featuresList.Find(x => x.Id == product.FeaturesId).MemoryType)
                                             select product;
                isCheckedItems = false;
            }

            List<int> memoryCapacityFilter = new List<int>();
            for (int i = 0; i < productsFilter.MemoryCapacities.Count; i++)
            {
                if (productsFilter.MemoryCapacities[i].IsChecked)
                {
                    memoryCapacityFilter.Add(productsViewModel.ProductsFilter.MemoryCapacities[i].Capacity);
                    isCheckedItems = true;
                }
            }

            if (isCheckedItems)
            {
                productsViewModel.Products = from product in productsViewModel.Products
                                             where memoryCapacityFilter.
                                             Contains(featuresList.Find(x => x.Id == product.FeaturesId).MemoryCapacity)
                                             select product;
                isCheckedItems = false;
            }

            pageInfo.CurrentPage = 1;
            pageInfo.ItemsPerPage = pageSize;
            pageInfo.TotalItems = productsViewModel.Products.Count();
            ViewBag.PageInfo = pageInfo;
            productsViewModel.Products = productsViewModel.Products.OrderBy(x => x.Id).Skip((productsFilter.IdPage - 1) * pageSize).Take(pageSize);

            if (productsFilter.SelectedIndex == 1) {
                productsViewModel.Products = from product in productsViewModel.Products
                                             orderby product.Price
                                             select product;
            }
            if (productsFilter.SelectedIndex == 2)
            {
                productsViewModel.Products = from product in productsViewModel.Products
                                             orderby product.Manufacturer
                                             select product;
            }
            if (productsFilter.SelectedIndex == 3)
            {
                productsViewModel.Products = from product in productsViewModel.Products
                                             orderby product.Name
                                             select product;
            }

            

            return View("Index", productsViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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