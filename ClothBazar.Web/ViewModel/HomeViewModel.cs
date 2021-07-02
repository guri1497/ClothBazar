using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.Web.ViewModel
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; }  // simple categories
        public List<Product> Products { get; set; } // simple products
        public List<Category> FeaturedCategories { get; set; } // features categories
        public List<Product> FeaturedProducts { get; set; } // featured products
        public Category Category { get; set; }
        public Product Product { get; set; }
        public int PageNo { get; set; }
    }
}