using System;
using System.Collections.Generic;
using PizzaApi.Models;
using System.Linq;

namespace PizzaApi.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private PizzaContext context;

        public PizzaRepository(PizzaContext context)
        {
            this.context = context;
        }

        public IEnumerable<Crust> GetCrusts()
        {
            return context.CrustItems.ToList();
        }

        public IEnumerable<Size> GetSizes()
        {
            return context.SizeItems.ToList();
        }

        public IEnumerable<Topping> GetToppings()
        {
            return context.ToppingItems.ToList();;
        }
    }
}