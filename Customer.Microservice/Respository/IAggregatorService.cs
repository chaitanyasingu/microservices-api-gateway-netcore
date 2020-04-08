using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Respository
{
    public interface IAggregatorService
    {
        Task<Models.CustomerOrder> GetOrdersByCustomerID(int customerId);
    }
}
