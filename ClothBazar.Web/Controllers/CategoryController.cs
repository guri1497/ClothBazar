using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();

        [HttpGet]
        public ActionResult Index() // get all categories
        {
            var categories = categoriesService.GetCategories();
            return View(categories);
        }

        [HttpGet]
        // GET: Category
        public ActionResult Edit(int ID) // edit new category 
        {
            var category = categoriesService.GetCategoryById(ID);
            return View(category);
        }

        [HttpPost]
        // GET: Category
        public ActionResult Edit(Category category) // edit category
        {
            categoriesService.UpdateCategory(category);
            return RedirectToAction("Index");
        }


        [HttpGet]
        // GET: Category
        public ActionResult Create() // create new category input field
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category) // save categories
        {
            categoriesService.SaveCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Category
        public ActionResult Delete(int ID) // edit new category 
        {
            var category = categoriesService.GetCategoryById(ID);
            return View(category);
        }

        [HttpPost]
        // GET: Category
        public ActionResult Delete(Category category) // edit category
        {
            categoriesService.DeleteCategory(category.ID);
            return RedirectToAction("Index");
        }

    }
}