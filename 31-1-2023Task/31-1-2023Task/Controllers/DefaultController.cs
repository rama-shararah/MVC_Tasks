using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace _31_1_2023Task.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Image()
        {
            return Content("<a href='/Images/jus.png' download><img src='..\\Images\\jus.PNG' width='100'><a>");

        }

        public string About()
        {
            return "About Page";
        }

        public string Contact()
        {
            return "Contact Page";
        }





        //public ActionResult Image()
        //{
        //    var imagePath = Path.Combine(Server.MapPath("~/Images"), "3a9eer.png");
        //    return File(imagePath, "image/jpeg");

        //}


        //public ActionResult DownloadAdTemplate(string pathCode)
        //{
        //    var imgPath = Server.MapPath(service.GetTemplatePath(pathCode));
        //    Response.AddHeader("Content-Disposition", "attachment;filename=DealerAdTemplate.png");
        //    Response.WriteFile(imgPath);
        //    Response.End();
        //    return null;
        //}

        //public FileResult ImageDownload(int id)
        //{
        //    var image = context.Images.Find(id);
        //    var imgPath = Server.MapPath(image.FilePath);
        //    return File(imgPath, "image/jpeg", image.FileName);
        //}

        //public ActionResult GetImage()
        //{
        //    string path = Server.MapPath("~/Images/3a9eer.PNG");
        //    byte[] imageByteData = System.IO.File.ReadAllBytes(path);
        //    return File(imageByteData, "image/png");
        //}

        //public ActionResult Image()
        //{
        //    return File("Image/3a9eer.png", "image/png");
        //}


        //public ActionResult GetImage(string id)
        //{
        //    var dir = Server.MapPath("/Images");
        //    var path = Path.Combine(dir, id + ".png");
        //    return base.File(path, "image/jpeg");
        //}
    }
}