using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.MicroService.DatabaseContext
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.PaymentType> PaymentTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source =DESKTOP-SB1FJH5;Initial Catalog=Order.Microservice;Integrated Security = true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.PaymentType>()
                .HasData(new Models.PaymentType() { PaymentTypeId =1, PaymentTypeDesc="COD" });
        }
    }
}
