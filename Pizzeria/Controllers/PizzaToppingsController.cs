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

namespace Pizzeria.Controllers
{
    public class PizzaToppingsController : Controller
    {
        private PizzasContext db = new PizzasContext();

        // GET: PizzaToppings
        public ActionResult Index()
        {
            return View(db.PizzaToppings.Include(x => x.Pizzas).ToList());
        }

        // GET: PizzaToppings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzaToppings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PizzaTopping pizzaTopping)
        {
            if (ModelState.IsValid)
            {
                db.PizzaToppings.Add(pizzaTopping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pizzaTopping);
        }

        // GET: PizzaToppings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaTopping pizzaTopping = db.PizzaToppings.Find(id);
            if (pizzaTopping == null)
            {
                return HttpNotFound();
            }
            return View(pizzaTopping);
        }

        // POST: PizzaToppings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PizzaTopping pizzaTopping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizzaTopping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizzaTopping);
        }

        // GET: PizzaToppings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaTopping pizzaTopping = db.PizzaToppings.Include(x => x.Pizzas).FirstOrDefault(x => x.Id == id);
            if (pizzaTopping == null)
            {
                return HttpNotFound();
            }
            return View(pizzaTopping);
        }

        // POST: PizzaToppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PizzaTopping pizzaTopping = db.PizzaToppings.Find(id);
            db.PizzaToppings.Remove(pizzaTopping);
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
