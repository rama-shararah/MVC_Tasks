using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _31_1_2023Task.Controllers
{
    public class RamaController : Controller
    {
        // GET: Rama
        public ActionResult Index()
        {
            return View();
        }

        public string Name()
        {
            return "<h1>Name:Rama<h1>";
        }



        public int Age()
        {

            return 22;
        }


        public string Friends()
        {

            return "Aya , Rahma , Batool , Haya , Lujain , Razan";

        }

        public string MyCat()
        {
            return "<img src=..\\Images\\Saloom.jpg width='500'>";
        }


    }
}