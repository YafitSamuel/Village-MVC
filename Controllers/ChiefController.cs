using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Village_MVC.Controllers
{
    public class ChiefController : Controller
    {
        // GET: Chief
        public ActionResult ShowChief()
        {
            ViewBag.ShowChief = "welcome Chief";
            return View();
          
        }

    }
}
