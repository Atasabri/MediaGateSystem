using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Accessories.Models;
using System.IO;
using Rotativa.MVC;

namespace Accessories.Controllers
{
    [Authorize]
    public class AccessoriesController : Controller
    {
        private DB db = new DB();

        // GET: Accessories
        public ActionResult Index(string search)
        {
            int Depart_ID = db.Users.Single(x => x.UserName == User.Identity.Name).Depart_ID.Value;
            if (search == null)
            {
                var accessories = db.Accessories.Where(x=>x.Depart_ID==Depart_ID).Include(a => a.Category).Include(a => a.Statue).Include(a => a.User);
                return View(accessories.ToList());
            }
            else
            {
                ViewData["Search"] = search;
                var accessories = db.Accessories.Where(x=>x.Name.Contains(search)&& x.Depart_ID == Depart_ID).Include(a => a.Category).Include(a => a.Statue).Include(a => a.User);
                return View(accessories.ToList());
            }
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Accessory accessory = db.Accessories.Find(id);
            int Depart_ID = db.Users.Single(x => x.UserName == User.Identity.Name).Depart_ID.Value;
            if (accessory == null)
            {
                return HttpNotFound();
            }
            if(accessory.Depart_ID!=Depart_ID)
            {
                return RedirectToAction("Index");
            }
            return View(accessory);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.Stat_ID = new SelectList(db.Statues, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.Users, "ID", "UserName");
            Session.Remove("Colors");
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Serial_Number,Model,Weight,Entry_Data,Departure_Date,Work_In,Buy_Date,Special_Prop,Quantity,Cat_ID,Stat_ID,User_ID,Location,SubCat1_ID,SubCat2_ID,Depart_ID")] Accessory accessory,List<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid&& files[0] != null)
            {
                if(Session["Colors"]!=null)
                {
                    List<color> List = Session["Colors"] as List<color>;
                    accessory.colors = List;
                }
                db.Accessories.Add(accessory);
                db.SaveChanges();
                foreach (HttpPostedFileBase File in files)
                {
                    File.SaveAs(Server.MapPath("~/Uploads/Img/"+accessory.ID+"IMG"+File.FileName));
                }
                Session.Remove("Colors");
                return RedirectToAction("Index");
            }

            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name", accessory.Cat_ID);
            ViewBag.Stat_ID = new SelectList(db.Statues, "ID", "Name", accessory.Stat_ID);
            ViewBag.User_ID = new SelectList(db.Users, "ID", "UserName", accessory.User_ID);
            return View(accessory);
        }

        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null )
            {
                return RedirectToAction("Index");
            }
            Accessory accessory = db.Accessories.Find(id);
            int Depart_ID = db.Users.Single(x => x.UserName == User.Identity.Name).Depart_ID.Value;
            if (accessory == null)
            {
                return HttpNotFound();
            }
            if( accessory.Depart_ID != Depart_ID)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name", accessory.Cat_ID);
            ViewBag.Stat_ID = new SelectList(db.Statues, "ID", "Name", accessory.Stat_ID);
            ViewBag.User_ID = new SelectList(db.Users, "ID", "UserName", accessory.User_ID);
            Session.Remove("Colors");
            return View(accessory);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Serial_Number,Model,Weight,Entry_Data,Departure_Date,Work_In,Buy_Date,Special_Prop,Quantity,Cat_ID,Stat_ID,User_ID,Location,SubCat1_ID,SubCat2_ID,Depart_ID")] Accessory accessory,List<HttpPostedFileBase>files)
        {
            if (ModelState.IsValid)
            {
                if (Session["Colors"] != null)
                {
                    List<color> List = Session["Colors"] as List<color>;
                    foreach (color item in List)
                    {
                        db.colors.Add(new color { Name = item.Name, Acc_ID = accessory.ID });
                    }
                }
                db.Entry(accessory).State = EntityState.Modified;
                db.SaveChanges();
                if(files[0]!=null)
                {
                    foreach (HttpPostedFileBase File in files)
                    {
                        File.SaveAs(Server.MapPath("~/Uploads/Img/" + accessory.ID +"IMG"+ File.FileName));
                    }
                }
                Session.Remove("Colors");
                return RedirectToAction("Index");
            }
            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name", accessory.Cat_ID);
            ViewBag.Stat_ID = new SelectList(db.Statues, "ID", "Name", accessory.Stat_ID);
            ViewBag.User_ID = new SelectList(db.Users, "ID", "UserName", accessory.User_ID);
            return View(accessory);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Accessory accessory = db.Accessories.Find(id);
            int Depart_ID = db.Users.Single(x => x.UserName == User.Identity.Name).Depart_ID.Value;
            if (accessory == null)
            {
                return HttpNotFound();
            }
            if (accessory.Depart_ID != Depart_ID)
            {
                return RedirectToAction("Index");
            }
            return View(accessory);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessory accessory = db.Accessories.Find(id);
            db.Accessories.Remove(accessory);
            db.SaveChanges();

            string[] Images= Directory.GetFiles(Server.MapPath("~/Uploads/Img/"), id+"IMG"+ "*");
            FileInfo File;
            foreach (string item in Images)
            {
                File = new FileInfo(item);
                if(File.Exists)
                {
                    File.Delete();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Addcolor(string color)
        {
            if(Session["Colors"]==null)
            {
                List<color> List = new List<color>();
                List.Add(new color { Name = color });
                Session["Colors"] = List;
            }
            else
            {
                List<color> List = Session["Colors"] as List<color>;
                List.Add(new color { Name = color });
                Session["Colors"] = List;
            }
            return PartialView("_Colors");
        }

        public ActionResult DeleteImg(string path,int id)
        {
            FileInfo File = new FileInfo(Server.MapPath("~/Uploads/Img/" + path));
            if(File.Exists)
            {
                File.Delete();
            }
            return RedirectToAction("Edit", new { @id = id });
        }
        public ActionResult DeleteColor(int colorid,int id)
        {
            color color = db.colors.Find(colorid);
            db.colors.Remove(color);
            db.SaveChanges();
            return RedirectToAction("Edit", new { @id = id });
        }

        [HttpPost]
        public ActionResult Search(FormCollection Form)
        {
            string AccessoriesName = Form["txtSearch"].ToString();
            var AccessoriesResult = db.Accessories.Where(x => x.Name.Contains(AccessoriesName)).Include(a => a.Category).Include(a => a.Statue).Include(a => a.User);
            ViewData["Search"] = Form["txtSearch"].ToString();
            return PartialView("_Search", AccessoriesResult);
        }

        public ActionResult GetSubCat(int Catid)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SubCat1> List = db.SubCat1.Where(x => x.Cat_ID == Catid).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubSubCat(int Catid)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SubCat2> List = db.SubCat2.Where(x => x.SubCat1_ID == Catid).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Expert(string Page,int? id,string search)
        {
            if(id==null)
            {
                if(search!=null)
                {
                    return new ActionAsPdf(Page, new { search = search })
                    {
                        FileName = "mediagate-search.pdf"
                    };
                }
                else
                {
                    return new ActionAsPdf(Page)
                    {
                        FileName = "mediagate.pdf"
                    };
                }
            }
            else
            {
                return new ActionAsPdf(Page, new { id = id })
                {
                    FileName="mediagate-details.pdf"
                };
            }
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
