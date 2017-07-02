using System.Collections.Generic;
using Newtonsoft.Json;

namespace PizzaApi.Models
{
    public class Topping
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<PizzaTopping> PizzaToppings { get; set; }
    }
}