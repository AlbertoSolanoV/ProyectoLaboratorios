    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevCodersUI.Controllers
{
    public class InformacionLabsController : Controller
    {
        // GET: InformacionLabs
        public ActionResult InformacionLabs()
        {
            if (Session["Rol"] != null)
            {
                return View();
            }
            else
            {

                return View();

                /*return RedirectToAction("../Login/Login");*/
            }
        }
    }
}