using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DevCodersUI.Controllers
{
    public class RegistroFormController : Controller
    {
        // GET: RegistroForm
        public ActionResult RegistroForm()
        {
            return View();
        }
    }
}