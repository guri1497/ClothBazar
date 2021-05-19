using ClothBazar.Data;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class CategoriesService
    {
        public List<Category> GetCategories() // get all category list
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategoryById(int ID) // get category by id
        {
            using (var context = new CBContext())
            {
                return context.Categories.Find(ID);
            }
        }

        public void SaveCategory(Category category) // save category
        {
            using(var context = new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category) // update category
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

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
