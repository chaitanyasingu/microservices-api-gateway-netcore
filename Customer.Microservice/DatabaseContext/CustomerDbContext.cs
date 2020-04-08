using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.DatabaseContext
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Models.Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source =DESKTOP-SB1FJH5;Initial Catalog=Customer.Microservice;Integrated Security = true;");
        }
    }
}
