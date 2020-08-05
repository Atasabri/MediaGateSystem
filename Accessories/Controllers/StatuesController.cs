using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Accessories.Models;

namespace Accessories.Controllers
{
    [Authorize]
    public class StatuesController : Controller
    {
        private DB db = new DB();

        // GET: Statues
        public ActionResult Index()
        {
            return View(db.Statues.ToList());
        }

        // GET: Statues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Statue statue = db.Statues.Find(id);
            if (statue == null)
            {
                return HttpNotFound();
            }
            return View(statue);
        }

        // GET: Statues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Statue statue)
        {
            if (ModelState.IsValid)
            {
                db.Statues.Add(statue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statue);
        }

        // GET: Statues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Statue statue = db.Statues.Find(id);
            if (statue == null)
            {
                return HttpNotFound();
            }
            return View(statue);
        }

        // POST: Statues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Statue statue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statue);
        }

        // GET: Statues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Statue statue = db.Statues.Find(id);
            if (statue == null)
            {
                return HttpNotFound();
            }
            return View(statue);
        }

        // POST: Statues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statue statue = db.Statues.Find(id);
            db.Statues.Remove(statue);
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
