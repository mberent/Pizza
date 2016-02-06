using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pizzeria.Contexts;
using Pizzeria.Models;
using Pizzeria.ViewModels;

namespace Pizzeria.Controllers
{
    public class PizzasController : Controller
    {
        private PizzasContext db = new PizzasContext();

        // GET: Pizzas
        public ActionResult Index(string search)
        {
            IEnumerable<Pizza> result = null;
            if (!string.IsNullOrWhiteSpace(search))
            {
                result = db.Pizzas.Where(x => x.Name.StartsWith(search)).ToList();
            }
            else
            {
                result = db.Pizzas.ToList();
            }

            return View(result);
        }

        // GET: Pizzas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pizza pizza = db.Pizzas
                .Include(x => x.PizzaToppings)
                .FirstOrDefault(x => x.Id == id);

            if (pizza == null)
            {
                return HttpNotFound();
            }

            return View(pizza);
        }

        //GET Pizzas/AddPizzaTopping/5
        public ActionResult AddPizzaTopping(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pizza = db.Pizzas
                .Include(x => x.PizzaToppings)
                .FirstOrDefault(x => x.Id == id);

            if (pizza == null)
            {
                return HttpNotFound();
            }

            var actualPizzaToppings = pizza.PizzaToppings.Select(x => x.Id).ToArray();

            var remainingPizzaToppings = db.PizzaToppings
                .Where(x => !actualPizzaToppings.Contains(x.Id))
                .ToArray();


            return View(new RemainingPizzaTopping { Pizza = pizza, PizzaToppings = remainingPizzaToppings });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPizzaTopping(int? id, int? toppingId)
        {
            if (id == null || toppingId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pizza = db.Pizzas.Find(id);
            var pizzaTopping = db.PizzaToppings.Find(toppingId);

            if (pizza == null || pizzaTopping == null)
            {
                return HttpNotFound();
            }

            pizza.PizzaToppings.Add(pizzaTopping);
            db.SaveChanges();

            return View("Details", pizza);
        }

        public ActionResult DeletePizzaTopping(int? id, int? toppingId)
        {
            if (id == null || toppingId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pizza = db.Pizzas.Find(id);
            var pizzaTopping = db.PizzaToppings.Find(toppingId);

            if (pizza == null || pizzaTopping == null)
            {
                return HttpNotFound();
            }

            pizza.PizzaToppings.Remove(pizzaTopping);
            db.SaveChanges();

            return View("Details", pizza);
        }

        // GET: Pizzas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PriceForSmall,PriceForMedium,PriceForLarge,Thickness")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Pizzas.Add(pizza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PriceForSmall,PriceForMedium,PriceForLarge,Thickness")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);
            db.Pizzas.Remove(pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
