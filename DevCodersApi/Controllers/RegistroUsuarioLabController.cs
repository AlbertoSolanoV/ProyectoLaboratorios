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
    public class RegistroUsuarioLabController : ApiController
    {
        [System.Web.Http.HttpPost]
        public string ReegistrarUsuarioLab(Usuario pUsuario)
        {
            AdminRegistroUsuarioLab admin = new AdminRegistroUsuarioLab();
            return admin.RegistrarUsuarioLab(pUsuario);
        }
    }
}
