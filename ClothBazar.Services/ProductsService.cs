using ClothBazar.Data;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClothBazar.Services
{
    /// <summary>
    /// get all products from database 
    /// </summary>
    /// <returns> all list of products </returns>
    public class ProductsService
    {
        #region Singleton
        public static ProductsService Instance { get // singleton method of using object of class
            {
                if (instance == null) instance = new ProductsService();
                return instance;
            } } 
        private static ProductsService instance { get; set; } // singleton
        public ProductsService()
        {

        }
        #endregion

        #region GetProducts
        public List<Product> GetProducts(int PageNo) // get all category list
        {
            var pageSize = 10;
            using (var context = new CBContext())
            {
                return context.Products.OrderBy(p=>p.ID).Skip((PageNo-1)*pageSize).Take(pageSize).Include(x=>x.Category).ToList(); // for paginaion
               // return context.Products.Include(x => x.Category).ToList(); // for paginaion
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

        public List<Product> GetProductByIDs(List<int> IDs) // get category by id
        {
            using (var context = new CBContext())
            {
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList();
            }
        }

        #endregion

        #region Creation
        /// <summary>
        /// saving new product into database
        /// </summary>
        /// <param name="product"> input receive from end user using view</param>
        public void SaveProduct(Product product) // save category
        {
            using (var context = new CBContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        #endregion

        #region Updation
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
        #endregion

        #region Deletion
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
        #endregion
    }
}
