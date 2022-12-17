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
    public class PorcentajeController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<Porcentaje> DevolverPorcentajes()
        {
            AdminPorcentaje admin = new AdminPorcentaje();
            return admin.devolverInfoPorcentajes();
        }

        [System.Web.Http.HttpPost]
        public string ModificarPorcentaje(Porcentaje pPorcentaje)
        {
            AdminPorcentaje admin = new AdminPorcentaje();
            return admin.modificarPorcentaje(pPorcentaje);
        }
    }
}