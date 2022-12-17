using AppLogic;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevCodersApi.Controllers
{
    public class OrdenDeCompraController : ApiController
    {
        //Metodos POST
        [HttpPost]
        public string ProcesarOrden(OrdenDeCompra pOrden)
        {
            AdminOrdenDeCompra admin = new AdminOrdenDeCompra();
            return admin.CrearOrdenDeCompra(pOrden);
        }

        public string ProcesarOrdenExamen(OrdenExamen pOrdenExamen)
        {
            AdminOrdenDeCompra admin = new AdminOrdenDeCompra();
            return admin.CrearOrdenExamen(pOrdenExamen);
        }

        /*-------------------------------------*/
        //Metodos GET
        [HttpGet]
        public OrdenDeCompra DevolverInfoOrdenDeCompra(string pIdAdmin)
        {
            AdminOrdenDeCompra admin = new AdminOrdenDeCompra();
            return admin.devolverInfoOrden(pIdAdmin);
        }

        [HttpGet]
        public List<OrdenDeCompra> DevolverTodasLasOrdenes()
        {
            AdminOrdenDeCompra admin = new AdminOrdenDeCompra();

            return admin.DevolverTodasLasOrdenes();
        }
    }
}