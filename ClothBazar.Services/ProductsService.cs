using ClothBazar.Data;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    /// <summary>
    /// get all products from database 
    /// </summary>
    /// <returns> all list of products </returns>
    public class ProductsService
    {
        public List<Product> GetProducts() // get all category list
        {
            using (var context = new CBContext())
            {
                return context.Products.ToList();
            }
        }

        // <summary>
        /// getting product by id from database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns> single product based on ID</returns>
        public Product GetProductById(int ID) // get category by id
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(ID);
            }
        }

        /// <summary>
        /// saving new product into database
        /// </summary>
        /// <param name="product"> input receive from end user using view</param>
        public void SaveProduct(Product product) // save category
        {
            using(var context = new CBContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// update product
        /// </summary>
        /// <param name="product"> product data from end user</param>
        public void UpdateProduct(Product product) // update category
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// delete product from database
        /// </summary>
        /// <param name="ID"> ID of product which we want to delete</param>
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
