using DevCodersUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DevCodersUI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return RedirectToAction("LandingTeam");
        }

        //public ActionResult RegistroForm()
        //{

        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult LandingProduct()
        {

            return View();
        }
        public ActionResult LandingTeam()
        {
            return View();
        }

        public ActionResult PaginaMain()
        {
            return View();
        }

        public ActionResult Factura()
        {
            if (Session["Rol"] != null)
            {

                return View();
            }
            else
            {

                return RedirectToAction("../Login/Login");
            }
        }

        public ActionResult RegistroLaboratorio()
        {
            return View();
        }

        public ActionResult registrarCitas()
        {
            if (Session["Rol"] != null)
            {

                return View();
            }
            else
            {

                return RedirectToAction("../Login/Login");
            }
        }
        public ActionResult registrarTExamenes()
        {
            return View();
        }
        public ActionResult mostrarExamenCliente()
        {
            return View();
        }

        public ActionResult mostrarHistorialExamenes()
        {
            return View();
        }

        public ActionResult mostrarTExamenes()
        {
            return View();
        }
        public ActionResult registrarExamen()
        {
            return View();
        }
        public ActionResult mostrarExamen()
        {
            return View();
        }
        public ActionResult CitasCliente()
        {
           

                return View();
            
           
        }

    }
}