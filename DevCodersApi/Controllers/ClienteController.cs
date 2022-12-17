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
    public class ClienteController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<Cliente> DevolverClientes(string pIdLab)
        {

            AdminClientes adminCliente = new AdminClientes();
            return adminCliente.devolverClientesLab(pIdLab);

        }
    }
}