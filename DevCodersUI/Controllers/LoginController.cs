using DTO;
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
    public class LoginController : Controller
    {
        public  ActionResult Login()
        {
            return View();
        }


    }
}