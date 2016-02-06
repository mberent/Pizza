using Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pizzeria.Contexts
{
    public class PizzasContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }

        public PizzasContext() : base("PizzasConnectionString") { }
    }
}