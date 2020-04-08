using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Microservice.Controllers
{
    [Route("api/customer/{id}/")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly Respository.IAggregatorService _aggregatorService;
        public CustomerOrderController(Respository.IAggregatorService aggregatorService)
        {
            _aggregatorService = aggregatorService;
        }

        [HttpGet]
        [Route("order/")]
        public async Task<IActionResult> GetOrderByCustomerId(int id)
        {
            var CustomerOrder = await _aggregatorService.GetOrdersByCustomerID(id);
            return new OkObjectResult(CustomerOrder);
        }
    }
}