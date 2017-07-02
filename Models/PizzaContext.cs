using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PizzaApi.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {

            if (this.ToppingItems.ToList().Count == 0)
            {
                this.ToppingItems.Add(new Topping { Name = "PEPPERONI" });
                this.ToppingItems.Add(new Topping { Name = "HAMBURGER" });
                this.ToppingItems.Add(new Topping { Name = "SAUSAGE" });
                this.ToppingItems.Add(new Topping { Name = "HAM" });
                this.ToppingItems.Add(new Topping { Name = "CHICKEN" });
                this.ToppingItems.Add(new Topping { Name = "BACON" });
                this.ToppingItems.Add(new Topping { Name = "ONIONS" });
                this.ToppingItems.Add(new Topping { Name = "PEPPERS" });
                this.ToppingItems.Add(new Topping { Name = "MUSHROOMS" });
                this.ToppingItems.Add(new Topping { Name = "TOMATOES" });
                this.ToppingItems.Add(new Topping { Name = "BLACK OLIVES" });
                this.ToppingItems.Add(new Topping { Name = "PINEAPPLE" });
            }

            if (this.CrustItems.ToList().Count == 0)
            {
                this.CrustItems.Add(new Crust { Name = "THIN" });
                this.CrustItems.Add(new Crust { Name = "PAN" });
                this.CrustItems.Add(new Crust { Name = "HAND TOSSED" });
                this.CrustItems.Add(new Crust { Name = "STUFFED CRUST" });
            }

            if (this.SizeItems.ToList().Count == 0)
            {
                this.SizeItems.Add(new Size { Name = "MEDIUM" });
                this.SizeItems.Add(new Size { Name = "LARGE" });
                this.SizeItems.Add(new Size { Name = "EXTRA LARGE" });
            }

            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaTopping>()
            .HasKey(pt => new { pt.PizzaId, pt.ToppingId });

            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Pizza)
                .WithMany(p => p.PizzaToppings)
                .HasForeignKey(pt => pt.PizzaId);

            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Topping)
                .WithMany(t => t.PizzaToppings)
                .HasForeignKey(pt => pt.ToppingId);
        }

        public DbSet<Pizza> PizzaItems { get; set; }
        public DbSet<Order> OrderItems { get; set; }
        public DbSet<Crust> CrustItems { get; set; }
        public DbSet<Size> SizeItems { get; set; }
        public DbSet<Topping> ToppingItems { get; set; }
        public DbSet<PizzaTopping> PizzaToppingItems { get; set; }
    }
}