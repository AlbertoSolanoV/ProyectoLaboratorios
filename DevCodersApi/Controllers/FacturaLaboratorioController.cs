using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DevCodersApi.Controllers
{
    public class FacturaLaboratorioController : ApiController
    {
        // GET: FacturaLaboratorio
        [System.Web.Http.HttpGet]
        public List<FacturaLaboratorio> FacturasLaboratoriosInfo()
        {
            AdminFacturaLab admin = new AdminFacturaLab();
            return admin.devolverInfoFacturasLab();
        }

        [System.Web.Http.HttpPost]
        public string RegistrarFacturaLaboratorio(FacturaLaboratorio pFactura)
        {
            AdminFacturaLab admin = new AdminFacturaLab();
            return admin.RegistrarFactura(pFactura);
        }

    }
}