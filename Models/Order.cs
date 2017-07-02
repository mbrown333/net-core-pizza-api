using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApi.Models
{
    public class Order
    {
        public Order()
        {
            this.Pizzas = new HashSet<Pizza>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public bool ReadyForDelivery { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }

        public bool AllPizzasReady() {
            foreach (var pizza in Pizzas)
            {
                if (!pizza.IsBaked)
                {
                    return false;
                }
            }

            return true;
        }
    }
}