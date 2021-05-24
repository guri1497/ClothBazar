using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller // controller added for all categories
    {
        CategoriesService categoriesService = new CategoriesService(); // obj for use all services
        /// <summary>
        /// index created for showing all categories
        /// </summary>
        /// <returns> index view and take categories </returns>
        [HttpGet]
        public ActionResult Index() // get all categories
        {
            return View();
        }

        public ActionResult CategoryTable()
        {
            var categories = categoriesService.GetCategories();
            return PartialView(categories);
        }

        /// <summary>
        /// create mehod for creating new category
        /// </summary>
        /// <returns> create view </returns>
        [HttpGet]
        public ActionResult Create() // create new category input field
        {
            return PartialView();
        }

        /// <summary>
        /// post method of create for saving new category
        /// </summary>
        /// <param name="category"> takes end user input from end user</param>
        /// <returns> redirect to index user for showing all category</returns>
        [HttpPost]
        public ActionResult Create(Category category) // save categories
        {
            categoriesService.SaveCategory(category);
            return RedirectToAction("CategoryTable");
        }

        /// <summary>
        /// edit categories
        /// </summary>
        /// <param name="ID"> id of category </param>
        /// <returns>edit view and take category </returns>
        [HttpGet]
        public ActionResult Edit(int ID) // edit new category 
        {
            var category = categoriesService.GetCategoryById(ID);
            return PartialView(category);
        }

        /// <summary>
        /// post method for saveing edited category
        /// </summary>
        /// <param name="category"> inpur received from end user </param>
        /// <returns> redirect to index method after saving data</returns>
        [HttpPost]
        public ActionResult Edit(Category category) // edit category
        {
            categoriesService.UpdateCategory(category);
            return RedirectToAction("CategoryTable");
        }

        /// <summary>
        /// delting the category
        /// </summary>
        /// <param name="category"></param>
        /// <returns> redirect to index method </returns>
        [HttpPost]
        public ActionResult Delete(Category category) // edit category
        {
            categoriesService.DeleteCategory(category.ID);
            return RedirectToAction("CategoryTable");
        }

    }
}