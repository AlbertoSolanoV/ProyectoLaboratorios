using DataAccess.CRUD;
using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminLogin
    {
        public Usuario devolverInfoUsuario(string pIdUser)
        {
            LoginCrudFactory loginCrud = new LoginCrudFactory();
            
            Usuario respuesta = loginCrud.RetrieveByTdLogin<Usuario>(pIdUser);

            return respuesta;
        }

        public Usuario ValidarLogin(Usuario usu)
        {
            LoginCrudFactory loginCrud = new LoginCrudFactory();

            Usuario respuesta = loginCrud.RetrieveByTdLogin<Usuario>(usu.emailUsuario);
            if(respuesta == null)
            {
                Usuario respuestaNull = new Usuario();
                respuestaNull.contraseñaUsuario = "incorrect";
                respuestaNull.OTPUsuario = "incorrect";
                return respuestaNull;
            }

            if (respuesta.contraseñaUsuario.Equals(usu.contraseñaUsuario)){
                return respuesta;

            }
            else
            {
                respuesta.contraseñaUsuario = "incorrect";
                respuesta.OTPUsuario = "incorrect";
            }
            return respuesta;

        }
    }
}


