﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class Product : BaseEntity // inherit all the members of BaseEntity class 
    { 
        public decimal Price { get; set; } // prop for product price
        public Category Category { get; set; } // prop for category of product
    }
}
