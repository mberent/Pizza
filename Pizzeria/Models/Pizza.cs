using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizzeria.Models
{
    public enum Thickness
    {
        [Display(Name = "Cienkie")]
        Thin,
        [Display(Name = "Grube")]
        Thick
    }

    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Pole wymagane")]
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Cena - mała")]
        public decimal PriceForSmall { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Cena - średnia")]
        public decimal PriceForMedium { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Cena - duża")]
        public decimal PriceForLarge { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Ciasto")]
        public Thickness Thickness { get; set; }

        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }

        public Pizza()
        {
            PizzaToppings = new HashSet<PizzaTopping>();
        }
    }
}