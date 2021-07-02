using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ConfigurationController : Controller
    {
        //ConfigurationsService configurationsService = new ConfigurationsService();
        // GET: Configuration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfigurationTable(string Search)
        {
            var config = ConfigurationsService.Instance.GetConfiguration();
            if (!string.IsNullOrEmpty(Search)) // using for search functionality
            {
                config = config.Where(c => c.Key != null && c.Key.ToLower().Contains(Search.ToLower())).ToList(); // filter data based on input
            }
            return PartialView(config);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Configuration config)
         {
            ConfigurationsService.Instance.SaveConfiguration(config);
            return RedirectToAction("ConfigurationTable");
        }

        [HttpGet]
        public ActionResult Edit(string Key)
        {
            var model = ConfigurationsService.Instance.GetConfigurationByKey(Key);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(Configuration configuration) // save categories
        {
            ConfigurationsService.Instance.UpdateConfiguration(configuration);
            return RedirectToAction("ConfigurationTable");
        }

        [HttpPost]
        public ActionResult Delete(string Key) // save categories
        {
            ConfigurationsService.Instance.DeleteConfiguration(Key);
            return RedirectToAction("ConfigurationTable");
        }

    }
}