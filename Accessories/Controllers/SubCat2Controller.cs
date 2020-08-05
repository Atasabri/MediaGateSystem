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
    public class SubCat2Controller : Controller
    {
        private DB db = new DB();

        // GET: SubCat2
        public ActionResult Index()
        {
            var subCat2 = db.SubCat2.Include(s => s.SubCat1);
            return View(subCat2.ToList());
        }

        // GET: SubCat2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            SubCat2 subCat2 = db.SubCat2.Find(id);
            if (subCat2 == null)
            {
                return HttpNotFound();
            }
            return View(subCat2);
        }

        // GET: SubCat2/Create
        public ActionResult Create()
        {
            ViewBag.SubCat1_ID = new SelectList(db.SubCat1, "ID", "Name");
            return View();
        }

        // POST: SubCat2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,SubCat1_ID")] SubCat2 subCat2)
        {
            if (ModelState.IsValid)
            {
                db.SubCat2.Add(subCat2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.SubCat1_ID = new SelectList(db.SubCat1, "ID", "Name", subCat2.SubCat1_ID);
            return View(subCat2);
        }

        // GET: SubCat2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            SubCat2 subCat2 = db.SubCat2.Find(id);
            if (subCat2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCat1_ID = new SelectList(db.SubCat1, "ID", "Name", subCat2.SubCat1_ID);
            return View(subCat2);
        }

        // POST: SubCat2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SubCat1_ID")] SubCat2 subCat2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCat2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.SubCat1_ID = new SelectList(db.SubCat1, "ID", "Name", subCat2.SubCat1_ID);
            return View(subCat2);
        }

        // GET: SubCat2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            SubCat2 subCat2 = db.SubCat2.Find(id);
            if (subCat2 == null)
            {
                return HttpNotFound();
            }
            return View(subCat2);
        }

        // POST: SubCat2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCat2 subCat2 = db.SubCat2.Find(id);
            db.SubCat2.Remove(subCat2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult GetSubCat(int Catid)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SubCat1> List = db.SubCat1.Where(x => x.Cat_ID == Catid).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetData(int subCat_id)
        {
            IEnumerable<SubCat2> Model = db.SubCat2.Where(x => x.SubCat1_ID == subCat_id);
            return PartialView("_GetData", Model);
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
