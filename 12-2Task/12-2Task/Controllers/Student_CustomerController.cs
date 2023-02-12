using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _12_2Task.Models;

namespace _12_2Task.Controllers
{
    public class Student_CustomerController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: Student_Customer
        public ActionResult Index()
        {
            var student_Customer = db.Student_Customer.Include(s => s.Cours).Include(s => s.Student);
            return View(student_Customer.ToList());
        }

        // GET: Student_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Customer student_Customer = db.Student_Customer.Find(id);
            if (student_Customer == null)
            {
                return HttpNotFound();
            }
            return View(student_Customer);
        }

        // GET: Student_Customer/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name");
            return View();
        }

        // POST: Student_Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,CourseId,Notes")] Student_Customer student_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Student_Customer.Add(student_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", student_Customer.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", student_Customer.StudentId);
            return View(student_Customer);
        }

        // GET: Student_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Customer student_Customer = db.Student_Customer.Find(id);
            if (student_Customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", student_Customer.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", student_Customer.StudentId);
            return View(student_Customer);
        }

        // POST: Student_Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,CourseId,Notes")] Student_Customer student_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", student_Customer.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", student_Customer.StudentId);
            return View(student_Customer);
        }

        // GET: Student_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Customer student_Customer = db.Student_Customer.Find(id);
            if (student_Customer == null)
            {
                return HttpNotFound();
            }
            return View(student_Customer);
        }

        // POST: Student_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Customer student_Customer = db.Student_Customer.Find(id);
            db.Student_Customer.Remove(student_Customer);
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
