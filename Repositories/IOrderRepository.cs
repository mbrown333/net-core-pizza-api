using System.Collections.Generic;
using PizzaApi.Models;

namespace PizzaApi.Repositories
{
    public interface IOrderRepository
    {
        bool Exists(long id);
        void Add(Order order);
        void Update(Order order);
        void Remove(long id);
        IEnumerable<Order> GetAll();
        Order GetById(long id);
    }
}