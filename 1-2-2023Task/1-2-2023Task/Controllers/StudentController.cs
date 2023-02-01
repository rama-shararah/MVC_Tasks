using _1_2_2023Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace _1_2_2023Task.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Students()
        {

            List<Models.Student> std = new List<Models.Student>();
            std.Add(new Student { ID = 28, Name = "Rahma", Major = "Software Engineer", Faculity = "IT" });
            std.Add(new Student { ID = 29, Name = "Rama", Major = "Finance", Faculity = "BF" });
            std.Add(new Student { ID = 6, Name = "Batool", Major = "Network and security", Faculity = "IT" });
            std.Add(new Student { ID = 5, Name = "Aya", Major = "housing Economic", Faculity = "IT" });
            std.Add(new Student { ID = 11, Name = "Haya", Major = "MIS", Faculity = "Al-balqaa" });
            std.Add(new Student { ID = 13, Name = "Lujain", Major = "CIS", Faculity = "IT" });


            return View(std);
        }
    }
}