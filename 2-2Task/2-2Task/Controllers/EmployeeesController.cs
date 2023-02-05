using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2_2Task.Models;
using System.IO;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using System.Runtime.Remoting.Contexts;


namespace _2_2Task.Controllers
{
    public class EmployeeesController : Controller
    {
        private AEntities db = new AEntities();

        // GET: Employeees
        public ActionResult Index(string searchBy, string search)
        {

            if (searchBy == "First_Name")
            {
                return View(db.Employeees.Where(x => x.First_Name.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "Last_Nama")
            {
                return View(db.Employeees.Where(x => x.Last_Nama.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(db.Employeees.Where(x => x.Email.Contains(search) || search == null).ToList());
            }
        }

        // GET: Employeees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = db.Employeees.Find(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // GET: Employeees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employeees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First_Name,Last_Nama,Email,Phone,Age,Job_Title,Gender")] Employeee employeee, HttpPostedFileBase pic, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path1 = "";
                string path2 = "";
                if (pic.FileName.Length > 0)
                {
                    path1 = Path.GetFileName(pic.FileName);
                    pic.SaveAs(Path.Combine(Server.MapPath("~/pic/"), pic.FileName));

                }
                if (file.FileName.Length > 0)
                {
                    path2 = Path.GetFileName(file.FileName);

                    file.SaveAs(Path.Combine(Server.MapPath("~/pdf/"), file.FileName));

                }

                employeee.Photo = path1;
                employeee.CV = path2;
                db.Employeees.Add(employeee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeee);
        }

        // GET: Employeees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = db.Employeees.Find(id);
            Session["photo"] = employeee.Photo;
            if (employeee == null)
            {
                return HttpNotFound();
            }

            return View(employeee);
        }

        // POST: Employeees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First_Name,Last_Nama,Email,Phone,Age,Job_Title,Gender")] Employeee employeee, HttpPostedFileBase pic, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string pathpic = "";
                string pathpdf = "";
                employeee.Photo = Session["photo"].ToString();

                if (pic != null)
                {
                    pathpic = Path.GetFileName(pic.FileName);
                    pic.SaveAs(Path.Combine(Server.MapPath("~/pic/"), pic.FileName));
                    employeee.Photo = pathpic;
                }

                if (file != null)
                {
                    pathpdf = Path.GetFileName(file.FileName);

                    file.SaveAs(Path.Combine(Server.MapPath("~/pdf/"), file.FileName));
                    employeee.CV = pathpdf;
                }


                db.Entry(employeee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeee);
        }

        // GET: Employeees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = db.Employeees.Find(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // POST: Employeees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employeee employeee = db.Employeees.Find(id);
            db.Employeees.Remove(employeee);
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
