using ClothBazar.Entities;
using ClothBazar.Services;
using ClothBazar.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller // controller added for all products
    {
        //ProductsService productsService = new ProductsService();  // object for use services
        //CategoriesService categoriesService = new CategoriesService();
        
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
        public ActionResult ProductTable(string search, int? pageNo) // this is main view of all product related operations
        {
            HomeViewModel model = new HomeViewModel();
            model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            // similar to above line
            //if (pageNo.HasValue)
            //{
            //    if (pageNo.Value > 0)
            //    {
            //        model.PageNo = pageNo.Value;
            //    }
            //    else
            //    {
            //        model.PageNo = 1;
            //    }
            //}
            //else
            //{
            //   model.PageNo = 1;
            //}
            model.Products = ProductsService.Instance.GetProducts(model.PageNo); //take all products

     
            if (!string.IsNullOrEmpty(search)) // using for search functionality
            {
                model.Products= model.Products.Where(p => p.Name != null &&  p.Name.ToLower().Contains(search.ToLower())).ToList(); // filter data based on input
            }
            return PartialView(model);
        }

        /// <summary>
        /// create mehod for creating new product
        /// </summary>
        /// <returns> create view </returns>
        [HttpGet]
        public ActionResult Create() // create new category input field
        {
            var categories = CategoriesService.Instance.GetAllCategories();
            return PartialView(categories);
        }

        /// <summary>
        /// post method of create for saving new product
        /// </summary>
        /// <param name="product"> takes end user input from end user</param>
        /// <returns> redirect to index user for showing all category</returns>
        [HttpPost]
        public ActionResult Create(NewCategoryViewModels newCategoryViewModels) // save categories
        {
            var newProduct = new Product();
            newProduct.Name = newCategoryViewModels.Name;
            newProduct.Price = newCategoryViewModels.Price;
            newProduct.Description = newCategoryViewModels.Description;
            newProduct.ImageURL = newCategoryViewModels.ImageURL;
            newProduct.CategoryID = newCategoryViewModels.CategoryID; // use this if dont want extra call to database see Product entity
            newProduct.Category = CategoriesService.Instance.GetCategoryById(newCategoryViewModels.CategoryID);
            ProductsService.Instance.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        /// <summary>
        /// edit controller for edit product 
        /// </summary>
        /// <param name="ID"> which product is editing </param>
        /// <returns>partial view of edit</returns>
        [HttpGet]
        public ActionResult Edit(int ID) // create new category input field
        {
            HomeViewModel model = new HomeViewModel();
            model.Product = ProductsService.Instance.GetProductById(ID);
            model.Categories = CategoriesService.Instance.GetAllCategories();
            return PartialView(model);
        }

        /// <summary>
        /// post method of edit product
        /// </summary>
        /// <param name="product"> takes updated data from end user</param>
        /// <returns> redirect to ProductTable Action </returns>
        [HttpPost]
        public ActionResult Edit(Product product) // save categories
        {
            ProductsService.Instance.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        /// <summary>
        /// for deleting the product
        /// </summary>
        /// <param name="ID"> which product is deleted</param>
        /// <returns>  redirect to ProductTable Action </returns>
        [HttpPost]
        public ActionResult Delete(int ID) // save categories
        {
            ProductsService.Instance.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}