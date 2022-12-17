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
    public class LoginController : ApiController
    {

        [HttpPost]
        public Usuario ValidarLogin(Usuario us)
        {
            AdminLogin admin = new AdminLogin();
            return admin.ValidarLogin(us);


        }

        [System.Web.Http.HttpGet]
        public Usuario LoginInformacionUsuario(string pIdUser)
        {
            AdminLogin usuario = new AdminLogin();
            return usuario.devolverInfoUsuario(pIdUser);
        }
    }
}
