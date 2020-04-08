using Microsoft.EntityFrameworkCore;
using Product.Microservice.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.DatabaseContext
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source =DESKTOP-SB1FJH5;Initial Catalog=Product.Microservice;Integrated Security = true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.ProductType>()
                .HasData(new Models.ProductType() { ProductTypeId = 1, ProductTypeDesc="Electronics"});
        }
        
    }
}
