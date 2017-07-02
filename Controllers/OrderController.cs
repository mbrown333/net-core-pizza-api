using System;
using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using System.Collections.Generic;
using PizzaApi.Repositories;

namespace PizzaApi.Controllers
{
    [Route("api/v1/order")]
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            orderRepository.Add(order);
            return Created("Create", order);
        }

        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return orderRepository.GetAll();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!orderRepository.Exists(order.Id))
            {
                return NotFound();
            }

            orderRepository.Update(order);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (!orderRepository.Exists(id))
            {
                return NotFound();
            }

            orderRepository.Remove(id);
            return new NoContentResult();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            if (!orderRepository.Exists(id))
            {
                return NotFound();
            }

            return new ObjectResult(orderRepository.GetById(id));
        }
    }
}