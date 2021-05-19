using ClothBazar.Data;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class ProductsService
    {
        public List<Product> GetProducts() // get all category list
        {
            using (var context = new CBContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProductById(int ID) // get category by id
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(ID);
            }
        }

        public void SaveProduct(Product product) // save category
        {
            using(var context = new CBContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product) // update category
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID) // delete category
        {
            using (var context = new CBContext())
            {
                //context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                var product = context.Products.Find(ID);
                context.Products.Remove(product); // both are working same
                context.SaveChanges();
            }
        }
    }
}
