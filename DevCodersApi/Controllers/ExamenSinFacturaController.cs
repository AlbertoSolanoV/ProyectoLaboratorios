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
    public class ExamenSinFacturaController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<ExamenesSinFactura> DevolverDatos(string idCliente)
        {
            AdminExamenesSinFactura admin = new AdminExamenesSinFactura();
            return admin.devolverInfoFacturasCitas(idCliente);
        }

        [System.Web.Http.HttpGet]
        public List<ExamenesSinFactura> DevolverCitasCliente(string idCliente)
        {
            AdminExamenesSinFactura admin = new AdminExamenesSinFactura();
            return admin.devolverInfoCitasCliente(idCliente);
        }

        [System.Web.Http.HttpPost]
        public string CrearCitaClienteLab(ExamenesSinFactura pExamen)
        {
            AdminExamenesSinFactura admin = new AdminExamenesSinFactura();
            return admin.crearCitaFactura(pExamen);
        }
    
    }
}
