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
    public class InfoLabController : ApiController
    {

        [System.Web.Http.HttpGet]
        public Laboratorio LaboratorioInformacion(string pidLaboratorio)
        {
            AdminInfoLab admin = new AdminInfoLab();
            return admin.devolverInfoLab(pidLaboratorio);
        }
    }
}
