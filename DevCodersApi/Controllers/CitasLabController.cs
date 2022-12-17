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
    public class CitasLabController : ApiController
    {
        [System.Web.Http.HttpPost]
        public string RegistrarCitaLab(CitaLaboratorio pCitaLab)
        {
            AdminCitasLaboratorio admin = new AdminCitasLaboratorio();
            return admin.RegistrarCitaLab(pCitaLab);
        }

        [System.Web.Http.HttpGet]
        public List<CitaLaboratorio> DevolverCitasLab(string pIdLab)
        {
            AdminCitasLaboratorio admin = new AdminCitasLaboratorio();
            return admin.devolverInfoCitasLab(pIdLab);
        }

        [System.Web.Http.HttpPost]
        public string EliminarCitaLab(string pIdCita)
        {
            AdminCitasLaboratorio admin = new AdminCitasLaboratorio();
            return admin.EliminarCitaLab(pIdCita);
        }
    }
}