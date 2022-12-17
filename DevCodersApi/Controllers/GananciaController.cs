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
    public class GananciaController : ApiController
    {
        // GET: Ganancia
        [System.Web.Http.HttpGet]
        public List<Ganancias> DevolverGanancia(string pId)
        {
            AdminGanancia admin = new AdminGanancia();
            return admin.devolverInfoGanancia(pId);
        }
    }
}