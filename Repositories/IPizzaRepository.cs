using System.Collections.Generic;
using PizzaApi.Models;

namespace PizzaApi.Repositories
{
    public interface IPizzaRepository
    {
        IEnumerable<Topping> GetToppings();
        IEnumerable<Size> GetSizes();
        IEnumerable<Crust> GetCrusts();
    }
}