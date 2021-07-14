using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StudentModel entities = new StudentModel();
            return View(entities.Students.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            StudentModel entities = new StudentModel();
            entities.Students.Add(new Student
            {
                //Name = Path.GetFileName(postedFile.FileName),
                //ContentType = postedFile.ContentType,
                //Data = bytes
            });
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Add()
        {
            Student s = new Student();
            return View(s);
        }

        [HttpPost]
        public ActionResult Add(Student model,HttpPostedFileBase image1)
        {
            var db = new StudentModel();
            if (image1 != null)
            {
                model.studentPic = new byte[image1.ContentLength];
                image1.InputStream.Read(model.studentPic, 0, image1.ContentLength);
            }
            db.Students.Add(model);
            db.SaveChanges();
            return View(model);
        }

        public ActionResult Display()
        {
            Student s = new Student();
            return View(s);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}