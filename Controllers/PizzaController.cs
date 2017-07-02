using System;
using Microsoft.AspNetCore.Mvc;
using PizzaApi.Repositories;
using PizzaApi.Models;
using System.Collections.Generic;

namespace PizzaApi.Controllers
{
    [Route("api/v1/pizza")]
    public class PizzaController : Controller
    {
        private IPizzaRepository pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            this.pizzaRepository = pizzaRepository;
        }

        [HttpGet("toppings", Name="GetToppings")]
        public IEnumerable<Topping> GetToppings()
        {
            return pizzaRepository.GetToppings();
        }

        [HttpGet("crusts", Name="GetCrusts")]
        public IEnumerable<Crust> GetCrusts()
        {
            return pizzaRepository.GetCrusts();
        }

        [HttpGet("sizes", Name="GetSizes")]
        public IEnumerable<Size> GetSizes()
        {
            return pizzaRepository.GetSizes();
        }
    }
}