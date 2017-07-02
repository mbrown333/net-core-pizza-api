using System;
using System.Collections.Generic;
using PizzaApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private PizzaContext context;

        public OrderRepository(PizzaContext context)
        {
            this.context = context;
        }

        public bool Exists(long id)
        {
            return context.OrderItems.Where(o => o.Id == id).First() != null;
        }

        public void Add(Order order)
        {
            context.OrderItems.Add(order);
            context.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = context.OrderItems.ToList();
            orders.ForEach(o =>
                o.Pizzas = context.PizzaItems
                    .Where(p => p.OrderId == o.Id)
                    .Include(p => p.PizzaToppings)
                    .ToList());

            return orders;
        }

        public Order GetById(long id)
        {
            var order = context.OrderItems.Where(o => o.Id == id).First();
            order.Pizzas = context.PizzaItems
                            .Where(p => p.OrderId == id)
                            .Include(p => p.PizzaToppings)
                            .ToList();
            return order;
        }

        public void Remove(long id)
        {
            if (!Exists(id))
            {
                return;
            }

            context.OrderItems.Remove(context.OrderItems.Where(o => o.Id == id).First());
            context.SaveChanges();
        }

        public void Update(Order order)
        {
            if (!Exists(order.Id))
            {
                return;
            }

            var savedOrder = GetById(order.Id);
            savedOrder.Name = order.Name;
            savedOrder.Address = order.Address;
            order.Pizzas.ToList().ForEach(p => {
                var pizza = context.PizzaItems.First(pi => pi.Id == p.Id);
                pizza.IsBaked = p.IsBaked;
                context.PizzaItems.Update(pizza);
            });
            savedOrder.ReadyForDelivery = order.AllPizzasReady();
            context.OrderItems.Update(savedOrder);
            context.SaveChanges();
        }
    }
}