using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Customer.Microservice.Respository
{
    public class CustomerOrder : IAggregatorService
    {
        #region Aggrigator methods
        public async Task<Models.CustomerOrder> GetOrdersByCustomerID(int customerId)
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44388/");
                try
                {
                    var response = await client.GetAsync("https://localhost:44388/api/order");
                    //var responseMessage = response.EnsureSuccessStatusCode();
                    CustomerRepository<Models.Customer> repo = new CustomerRepository<Models.Customer>();
                    //if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return new Models.CustomerOrder()
                        {
                            Customer = JsonConvert.SerializeObject(repo.GetBy(customerId)),
                            Order = await response.Content.ReadAsStringAsync(),
                        };
                    }
                    return new Models.CustomerOrder()
                    {
                        Customer = JsonConvert.SerializeObject(new CustomerRepository<Models.Customer>().GetBy(customerId)),
                    };
                }
                catch(Exception ep)
                {
                    return null;
                }
            }
        }
        #endregion
    }
}
