using DevCodersUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DevCodersUI.Controllers
{
    public class ProcesoDePagoController : Controller
    {
        // GET: ProcesoDePago
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrdenDeCompra()
        {
            if (Session["Rol"] != null)
            {

                return View();
            }
            else
            {
                return View();
                //return RedirectToAction("../Login/Login");
            }
        }

        public ActionResult PaypalProcess(string Cancel = null)
        {
            APIHelper helper = new APIHelper();

            var PayerApprovedOrderId = Request["token"];
            var PayerID = Request["PayerID"];

            var url = helper.GetAPIUrl(Request.Url.Host);
            url = url + "/api/Paypal/ExcecutePaypalOrder";

            url = url + string.Format("?PayerApprovedOrderId={0}&PayerID={1}", PayerApprovedOrderId, PayerID);


            //Revisar si es una cancelación, antes de enviar a crear la Orden
            if (!string.IsNullOrEmpty(Cancel) && Cancel.Trim().ToLower() == "true")
            {
                ViewBag.Message = "Orden ha sido Cancelada!";
                return RedirectToAction("Paypal");
            }

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            var result = cliente.PostAsync(url, null).Result;


            if (result.IsSuccessStatusCode)
            {
                ViewBag.Message = "Pago Procesado Correctamente!!";
            }
            else
            {
                ViewBag.Message = "Hubo un Problema al procesar el Pago";
            }
            return RedirectToAction("Paypal");
        }

        public ActionResult Paypal()
        {
            var idOrden = Request.QueryString["IdOrden"];
            var nombreCliente = Request.QueryString["NombreCliente"];
            var nombreLab = Request.QueryString["NombreLab"];
            var total = Request.QueryString["Total"];
            var subTotal = Request.QueryString["SubTotal"];
            var descuento = Request.QueryString["Descuento"];
            var IVA = Request.QueryString["IVA"];

            ViewData["orden"] = idOrden;
            ViewData["laboratorio"] = nombreLab;
            ViewData["nombre"] = nombreCliente;
            ViewData["total"] = total;
            ViewData["subTotal"] = subTotal;
            ViewData["descuento"] = descuento;
            ViewData["IVA"] = IVA;

            return View();
        }

        public ActionResult CarritoCompra()
        {
            
            var nombreExamen = Request.QueryString["nombreExamen"];
            var precioExamen = Request.QueryString["precioExamen"];

            ViewData["nombre"] = nombreExamen;
            ViewData["precio"] = precioExamen;

            return View();
        }
    }
}