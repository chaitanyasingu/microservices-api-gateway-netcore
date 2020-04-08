using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Respository;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Domain.Core.IRepository.IBaseCRUD<Models.Product> _productRepository;

        public ProductController(Domain.Core.IRepository.IBaseCRUD<Models.Product> productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Products = _productRepository.Get();
            return new OkObjectResult(Products);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Models.Product product)
        {
            return new OkObjectResult(_productRepository.Add(product));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new OkObjectResult(_productRepository.DeleteByID(id));
        }
         
        [HttpPut]
        public IActionResult Put([FromBody] Models.Product product)
        {
            return new OkObjectResult(_productRepository.Update(product));
        }
    }
}