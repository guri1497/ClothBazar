using ClothBazar.Data;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class ConfigurationsService
    {
        #region Singleton
        public static ConfigurationsService Instance
        {
            get // singleton method of using object of class
            {
                if (instance == null) instance = new ConfigurationsService();
                return instance;
            }
        }
        private static ConfigurationsService instance { get; set; } // singleton
        public ConfigurationsService()
        {

        }
        #endregion
        public List<Configuration> GetConfiguration() // get all category list
        {
            using (var context = new CBContext())
            {
                return context.Configurations.ToList();
            }
        }

        // <summary>
        /// getting product by id from database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns> single product based on ID</returns>
        public Configuration GetConfigurationByKey(string key) // get category by id
        {
            using (var context = new CBContext())
            {
                return context.Configurations.Find(key);
            }
        }

        public List<Configuration> GetConfigurationsByKeys(List<string> keys) // get category by id
        {
            using (var context = new CBContext())
            {
                return context.Configurations.Where(config => keys.Contains(config.Key)).ToList();
            }
        }

        /// <summary>
        /// saving new product into database
        /// </summary>
        /// <param name="product"> input receive from end user using view</param>
        public void SaveConfiguration(Configuration configuration) // save category
        {
            using (var context = new CBContext())
            {
                context.Configurations.Add(configuration);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// update product
        /// </summary>
        /// <param name="product"> product data from end user</param>
        public void UpdateConfiguration(Configuration configuration) // update category
        {
            using (var context = new CBContext())
            {
                context.Entry(configuration).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// delete product from database
        /// </summary>
        /// <param name="ID"> ID of product which we want to delete</param>
        public void DeleteConfiguration(string key) // delete category
        {
            using (var context = new CBContext())
            {
                //context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                var config = context.Configurations.Find(key);
                context.Configurations.Remove(config); // both are working same
                context.SaveChanges();
            }
        }
    }
}
