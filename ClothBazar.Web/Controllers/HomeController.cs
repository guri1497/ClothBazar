using ClothBazar.Services;
using ClothBazar.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class HomeController : Controller
    {
        CategoriesService categoriesService = new CategoriesService(); // obj for use all services
        HomeViewModel homeViewModel = new HomeViewModel();
        
        public ActionResult Index()
        {
            //homeViewModel.Categories = categoriesService.GetCategories(); // simple all category list
            homeViewModel.FeaturedCategories = categoriesService.GetFeaturedCategories(); // featured categories
            return View(homeViewModel);
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
    }
}