using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller // controller added for all products
    {
        ProductsService productsService = new ProductsService();  // object for use services
        
        /// <summary>
        /// showing all products
        /// </summary>
        /// <returns> index view</returns>
        public ActionResult Index() // showing all products 
        {
            return View();
        }

        /// <summary>
        /// getting all products 
        /// </summary>
        /// <returns> product view </returns>
        public ActionResult ProductTable(string search) // getting all products
        {
            var products = productsService.GetProducts();
            if(!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name != null &&  p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(products);
        }

        /// <summary>
        /// create mehod for creating new product
        /// </summary>
        /// <returns> create view </returns>
        [HttpGet]
        public ActionResult Create() // create new category input field
        {
            return PartialView();
        }

        /// <summary>
        /// post method of create for saving new product
        /// </summary>
        /// <param name="product"> takes end user input from end user</param>
        /// <returns> redirect to index user for showing all category</returns>
        [HttpPost]
        public ActionResult Create(Product product) // save categories
        {
            productsService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID) // create new category input field
        {
            var product = productsService.GetProductById(ID);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product) // save categories
        {
            productsService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID) // save categories
        {
            productsService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}