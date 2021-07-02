using ClothBazar.Services;
using ClothBazar.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ShopController : Controller
    {
        // ProductsService productsService = new ProductsService();
        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();
            var productCookie = Request.Cookies["CartProducts"]; // request browser for take cookies
            if (productCookie != null) // check if cookie is null
            {
                var pIDs = productCookie.Value; // take value of cookies
                var productIDs = pIDs.Split('-').Select(x => int.Parse(x)).ToList(); // first split string then convert to int the to list return list of int
                model.ProductIDs = productIDs;
                model.CartProducts = ProductsService.Instance.GetProductByIDs(productIDs);
            }
            
            return View(model);
        }
    }
}