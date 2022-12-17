using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DevCodersApi.Controllers
{
    
    public class RegistroUsuarioController : ApiController
    {
        [System.Web.Http.HttpPost]
        public string RegistrarUsuario(Usuario pUsuario)
        {
            AdminRegistroUsuario adminRegistroUsuario= new AdminRegistroUsuario();
            return adminRegistroUsuario.RegistrarUsuario(pUsuario);
        }

        [System.Web.Http.HttpPost]
        public Usuario ValidarCorreo(Usuario us)
        {
            AdminRegistroUsuario admin = new AdminRegistroUsuario();
            return admin.ValidarCorreo(us);

        }

        [System.Web.Http.HttpGet]
        public Usuario InformacionUsuario(string pIdUsuario)
        {
            AdminRegistroUsuario adminRegistroUsuario = new AdminRegistroUsuario();
            return adminRegistroUsuario.devolverInformacionUsuarios(pIdUsuario);
        }

        [System.Web.Http.HttpGet]
        public List<Usuario> InformacionTodosUsuarios()
        {
            AdminRegistroUsuario listaTodosUsuario = new AdminRegistroUsuario();
            return listaTodosUsuario.devolverInformacionTodosUsuarios();
        }
        [System.Web.Http.HttpGet]
        public Usuario InformacionUsuarioPorCorreo(string correo)
        {
            AdminRegistroUsuario adminRegistroUsuario = new AdminRegistroUsuario();
            return adminRegistroUsuario.devolverInformacionUsuariosCorreo(correo);
        }

        [System.Web.Http.HttpPost]
        public string ModificarUsuarioContrasena(Usuario pIdUsuario)
        {
            AdminRegistroUsuario admin = new AdminRegistroUsuario();
            return admin.modificarUsuarioContraseña(pIdUsuario);
        }

        public string ModificarUsuarioActivo(Usuario pIdUsuario)
        {
            AdminRegistroUsuario admin = new AdminRegistroUsuario();
            return admin.modificarUsuarioActivo(pIdUsuario);
        }

        [System.Web.Http.HttpPost]
        public string ModificarUsuario(Usuario pUsuario)
        {
            AdminRegistroUsuario admin = new AdminRegistroUsuario();
            return admin.modificarUsuario(pUsuario);
        }

    }
}