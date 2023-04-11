using ExamFormFilling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamFormFilling.Controllers
{
    public class HomeController : Controller
    {
        MospheDbEntities _db = new MospheDbEntities();

        public ActionResult Registration()
        {
            Registration tbl = new Registration();
            return View(tbl);
        }

        [HttpPost]
        public ActionResult Registration(Registration model)
        {
            _db.Registrations.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {

            Registration tbl = new Registration();
            return View(tbl);

        }

        [HttpPost]
        public ActionResult Login(Registration model)
        {
            if(model!=null)
            {
                var student = _db.Registrations.Where(x => x.Firstname == model.Firstname && x.Lastname == model.Lastname && x.Password == model.Password).FirstOrDefault();
                if(student!=null)
                {
                    return View("ExamForm");
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                return View("Index");

            }
            
        }


        public ActionResult ExamForm()
        {
            return View();
        }



        public ActionResult Index()
        {
            return View();
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