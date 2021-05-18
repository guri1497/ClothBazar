using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Database
{
    public class CBContext : DbContext //inherit for make our entity database
    {
        public CBContext():base("ClothBazarConnection") // tell dbcontext file which connection is use
        {

        }
        public DbSet<Category> Categories { get; set; } // individullay create database table
        public DbSet<Product> Products { get; set; } // individullay create database table
    }
}
