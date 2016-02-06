using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizzeria.Models
{
    public class PizzaTopping
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}