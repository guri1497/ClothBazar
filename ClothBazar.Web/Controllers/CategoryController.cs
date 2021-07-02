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
    public class CategoryController : Controller // controller added for all categories
    {
        // CategoriesService categoriesService = new CategoriesService(); // obj for use all services // because use singleton thats why comment
        
        
        /// <summary>
        /// index created for showing all categories
        /// </summary>
        /// <returns> index view and take categories </returns>
        [HttpGet]
        public ActionResult Index() // get all categories
        {
            return View();
        }

        public ActionResult CategoryTable(int? pageNo)
        {
            CategorySearchViewModel model = new CategorySearchViewModel();
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            //int pageSize = 5;
            
            var totalRecords = CategoriesService.Instance.GetCategoriesCount();
            model.Categories = CategoriesService.Instance.GetCategories(pageNo.Value);
          
            if (model.Categories != null)
            {
                model.Pager = new Pager(totalRecords, pageNo, 3);
            }
            else
            {
                return HttpNotFound();
            }
            
            
            return PartialView(model);
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
            CategoriesService.Instance.SaveCategory(category);
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
            var category = CategoriesService.Instance.GetCategoryById(ID);
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
            CategoriesService.Instance.UpdateCategory(category);
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
            CategoriesService.Instance.DeleteCategory(category.ID);
            return RedirectToAction("CategoryTable");
        }

    }
}