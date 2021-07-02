using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.Web.ViewModel
{
    public class ProductSearchViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } // prop for product price
        public int CategoryID { get; set; } // used for tell product entity that category is already exist at a new product creation see ProductController/Create 
        public virtual Category Category { get; set; } // prop for category of product
        public string ImageURL { get; set; }
    }
}