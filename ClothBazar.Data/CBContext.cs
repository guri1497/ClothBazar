using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Data
{
    /// <summary>
    /// create cbcontext class inherit from dbcontext class
    /// </summary>
   public class CBContext:DbContext,IDisposable
    {
        /// <summary>
        /// overrider contrustor which tells which database string is used
        /// </summary>
        public CBContext():base("ClothBazarConnection")
        {

        }
        public DbSet<Category> Categories { get; set; } // for creating category table in database
        public DbSet<Product> Products { get; set; } // for creating product table in database
        public DbSet<Configuration> Configurations { get; set; } // for creating config table in database
    }
}
