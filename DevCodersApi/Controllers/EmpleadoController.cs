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
    public class EmpleadoController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<EmpleadoLab> DevolverEmpleados(string pIdLab)
        {

            AdminEmpleados adminEmpleado = new AdminEmpleados();
            return adminEmpleado.devolverEmpleadosLab(pIdLab);

        }

        [System.Web.Http.HttpGet]
        public EmpleadoLab DevolverLabEmpleado(string pIdEmpleado)
        {

            AdminEmpleados adminEmpleado = new AdminEmpleados();
            return adminEmpleado.devolverLabEmpleado(pIdEmpleado);

        }

    }
}