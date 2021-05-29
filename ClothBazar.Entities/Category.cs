using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class Category : BaseEntity // inherit all the members and propertys of base class
    {
        public string ImageURL { get; set; }
        public virtual List<Product> Products { get; set; } // prop for showing products under category
        public bool isFeatured { get; set; }
    }
}
