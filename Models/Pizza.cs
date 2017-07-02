using System.Collections.Generic;
using Newtonsoft.Json;

namespace PizzaApi.Models
{
    public class Pizza
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        [JsonIgnore]
        public Order order { get; set; }
        public long SizeId { get; set; }
        public virtual Size Size { get; set; }
        public long CrustId { get; set; }
        public virtual Crust Crust { get; set; }
        public List<PizzaTopping> PizzaToppings { get; set; }
        public bool IsBaked { get; set; }
    }
}