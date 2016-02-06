using Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzeria.ViewModels
{
    public class RemainingPizzaTopping
    {
        public Pizza Pizza { get; set; }
        public IEnumerable<PizzaTopping> PizzaToppings { get; set; }
    }
}