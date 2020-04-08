using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order.MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Domain.Core.IRepository.IBaseCRUD<Models.Order> _orderRepository;

        public OrderController(Domain.Core.IRepository.IBaseCRUD<Models.Order> orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Products = _orderRepository.Get();
            return new OkObjectResult(Products);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Models.Order order)
        {
            return new OkObjectResult(_orderRepository.Add(order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new OkObjectResult(_orderRepository.DeleteByID(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Models.Order order)
        {
            return new OkObjectResult(_orderRepository.Update(order));
        }
    }
}