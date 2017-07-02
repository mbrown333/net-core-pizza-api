using Newtonsoft.Json;

namespace PizzaApi.Models
{
    public class PizzaTopping
    {
        public long PizzaId { get; set; }
        [JsonIgnore]
        public Pizza Pizza { get; set; }

        public long ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}