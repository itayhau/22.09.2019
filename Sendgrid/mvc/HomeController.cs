using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebWithPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ConfirmEmail()
        {
            ViewBag.Title = "Email Confirmation Page";

            var c = Request.QueryString;
            var id = c.Get("id");
            
            //  add Views/View/Error.html
            //     <p style="background:red">
            //     <b>Bad Error!!</b>
            //     </p>
            //  return new FilePathResult("~/Views/View/Error.html", "text/html");
            return View("ConfirmEmail");
        }
    }
}

