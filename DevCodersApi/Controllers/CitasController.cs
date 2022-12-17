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
    public class CitasController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<Citas> DevolverCitasLab(string pId)
        {
            AdminCita admin = new AdminCita();
            return admin.devolverInfoCitasLab(pId);
        }

        [System.Web.Http.HttpPost]
        public string CancelarCita(Citas pCita)
        {
            AdminCita admin = new AdminCita();
            return admin.cancelarCita(pCita);
        }

    }
}