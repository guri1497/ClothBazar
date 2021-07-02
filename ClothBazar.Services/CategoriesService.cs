using ClothBazar.Data;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class CategoriesService
    {

        public static CategoriesService Instance
        {
            get // singleton method of using object of class
            {
                if (instance == null) instance = new CategoriesService();
                return instance;
            }
        }
        private static CategoriesService instance { get; set; } // singleton
        public CategoriesService()
        {

        }

        public int GetCategoriesCount() // get all category list
        {
            using (var context = new CBContext())
            {
                return context.Categories.Count();
            }
        }
        public List<Category> GetAllCategories() // get all category list
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();

            }
        }

        /// <summary>
        /// get all categories from database 
        /// </summary>
        /// <returns> all list of categories </returns>
        public List<Category> GetCategories(int PageNo) // get all category list
        {
            var pageSize = 3; //int.Parse(ConfigurationsService.Instance.GetConfigurationByKey("ListingPageSize").Value);
            using (var context = new CBContext())
            {
                return context.Categories.OrderBy(p => p.ID).Skip((PageNo - 1) * pageSize).Take(pageSize).Include(x => x.Products).ToList();
            }
        }

        public List<Category> GetFeaturedCategories() // get all category list
        {
            using (var context = new CBContext())
            {
                return context.Categories.Where(x => x.isFeatured && x.ImageURL!= null).ToList();
            }
        }

        /// <summary>
        /// getting category by id from database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns> single category based on ID</returns>
        public Category GetCategoryById(int ID) // get category by id
        {
            using (var context = new CBContext())
            {
                return context.Categories.Find(ID);
            }
        }

        /// <summary>
        /// saving new category into database
        /// </summary>
        /// <param name="category"> input receive from end user using view</param>
        public void SaveCategory(Category category) // save category
        {
            using(var context = new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"> category data from end user</param>
        public void UpdateCategory(Category category) // update category
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// delete category from database
        /// </summary>
        /// <param name="ID"> ID of category which we want to delete</param>
        public void DeleteCategory(int ID) // delete category
        {
            using (var context = new CBContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var category = context.Categories.Find(ID);
                context.Categories.Remove(category); // both are working same
                context.SaveChanges();
            }
        }
    }
}
