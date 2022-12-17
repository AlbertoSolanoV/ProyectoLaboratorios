using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminValidarOTP
    {

        public Usuario ValidarOTP(Usuario usu)
        {
            OTPCrudFactory otpCrud = new OTPCrudFactory();

            Usuario respuesta = otpCrud.RetrieveByTdCorreo<Usuario>(usu.emailUsuario);
            if (respuesta == null)
            {
                Usuario respuestaNull = new Usuario();
                respuestaNull.OTPUsuario = "incorrect";
                return respuestaNull;
            }

            if (respuesta.emailUsuario.Equals(usu.emailUsuario))
            {
                return respuesta;
            }
            else
            {
                
                respuesta.OTPUsuario = "incorrect";
            }
            return respuesta;

        }
    }
}
