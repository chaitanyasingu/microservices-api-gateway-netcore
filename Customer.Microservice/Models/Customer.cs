using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
      
    }

    public class CustomerOrder
    {
        public string Customer { get; set; }
        public string Order { get; set; }
    }
}
