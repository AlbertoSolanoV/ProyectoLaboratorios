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
    public class ExamenInfoLabController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<Examen> InformacionExamen(string pIdExamen)
        {
            AdminExamenInfoLab adminExamenInfoLab = new AdminExamenInfoLab();
            return adminExamenInfoLab.devolverInformacionExamenes(pIdExamen);
        }

        [System.Web.Http.HttpGet]
        public List<Examen> InformacionTodosExamenes()
        {
            AdminExamenInfoLab listaTodosExamenes = new AdminExamenInfoLab();
            return listaTodosExamenes.devolverInformacionTodosUsuarios();
        }
    }
}
