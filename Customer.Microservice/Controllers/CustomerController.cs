using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Domain.Core.IRepository.IBaseCRUD<Models.Customer> _customerRepository;
        #region CRUD
        public CustomerController(Domain.Core.IRepository.IBaseCRUD<Models.Customer> productRepository)
        {
            this._customerRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Customers = _customerRepository.Get();
            return new OkObjectResult(Customers);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Models.Customer product)
        {
            return new OkObjectResult(_customerRepository.Add(product));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new OkObjectResult(_customerRepository.DeleteByID(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Models.Customer product)
        {
            return new OkObjectResult(_customerRepository.Update(product));
        }
        #endregion


        [HttpGet]
        [Route("api/customer/{id}/order")]
        public IActionResult GetOrdersByCustomerId()
        {
            return Ok();
        }

       
    }
}