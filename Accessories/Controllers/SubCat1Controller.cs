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
    public class SubCat1Controller : Controller
    {
        private DB db = new DB();

        // GET: SubCat1
        public ActionResult Index()
        {
            var subCat1 = db.SubCat1.Include(s => s.Category);
            return View(subCat1.ToList());
        }

        // GET: SubCat1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            SubCat1 subCat1 = db.SubCat1.Find(id);
            if (subCat1 == null)
            {
                return HttpNotFound();
            }
            return View(subCat1);
        }

        // GET: SubCat1/Create
        public ActionResult Create()
        {
            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: SubCat1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Cat_ID")] SubCat1 subCat1)
        {
            if (ModelState.IsValid)
            {
                db.SubCat1.Add(subCat1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name", subCat1.Cat_ID);
            return View(subCat1);
        }

        // GET: SubCat1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            SubCat1 subCat1 = db.SubCat1.Find(id);
            if (subCat1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name", subCat1.Cat_ID);
            return View(subCat1);
        }

        // POST: SubCat1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Cat_ID")] SubCat1 subCat1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCat1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name", subCat1.Cat_ID);
            return View(subCat1);
        }

        // GET: SubCat1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            SubCat1 subCat1 = db.SubCat1.Find(id);
            if (subCat1 == null)
            {
                return HttpNotFound();
            }
            return View(subCat1);
        }

        // POST: SubCat1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCat1 subCat1 = db.SubCat1.Find(id);
            db.SubCat1.Remove(subCat1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetData(int Cat_ID)
        {
            IEnumerable<SubCat1> Model = db.SubCat1.Where(x => x.Cat_ID == Cat_ID).Include(z => z.Category);
            return PartialView("_GetData",Model);
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
