using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevCodersApi.Controllers
{
    public class FacturaController : ApiController
    {
        // GET: FacturaLaboratorio
        [System.Web.Http.HttpGet]
        public List<Factura> FacturasInfo()
        {
            AdminFactura admin = new AdminFactura();
            return admin.devolverInfoFacturas();
        }

        [System.Web.Http.HttpPost]
        public string RegistrarFactura(Factura pFactura)
        {
            AdminFactura admin = new AdminFactura();
            return admin.RegistrarFactura(pFactura);
        }
    }
}
