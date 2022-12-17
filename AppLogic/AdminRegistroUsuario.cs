using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CRUD;

namespace AppLogic
{
    public class AdminRegistroUsuario
    {


        public string RegistrarUsuario(Usuario pDatosUsuario)
        {
            RegistroUsuarioCrudFactory registrarUsuario = new RegistroUsuarioCrudFactory();
            return registrarUsuario.CreateRespuesta(pDatosUsuario);
            

        }

        public Usuario devolverInformacionUsuarios(string pIdUsuario)
        {
            RegistroUsuarioCrudFactory listaUsuarioCrud = new RegistroUsuarioCrudFactory();
            int id = Int32.Parse(pIdUsuario);
            Usuario respuesta = listaUsuarioCrud.RetrieveByTd<Usuario>(id);
            return respuesta;
        }

        public Usuario devolverInformacionUsuariosCorreo(string pCorreo)
        {
            ReinicioContraseñaCrudFactory UsuarioCrud = new ReinicioContraseñaCrudFactory();
            string correo = pCorreo;
            Usuario respuesta = UsuarioCrud.RetrieveByTdCorreo<Usuario>(correo);
            return respuesta;
        }

        public List<Usuario> devolverInformacionTodosUsuarios()
        {
            RegistroUsuarioCrudFactory listaUsuarioCrud = new RegistroUsuarioCrudFactory();
            return listaUsuarioCrud.RetrieveAll<Usuario>();
        }

        public string UpdateUsuario(Usuario pDatosUsuario)
        {

            try
            {
                RegistroUsuarioCrudFactory updateUsuario = new RegistroUsuarioCrudFactory();
                updateUsuario.Update(pDatosUsuario);
                return "Usuario modificado con exito";
            }
            catch (Exception e)
            {
                return "Sucedio un error " + e;
            }
           

        }

        public Usuario ValidarCorreo(Usuario usu)
        {
            ReinicioContraseñaCrudFactory correoCrud = new ReinicioContraseñaCrudFactory();

            Usuario respuesta = correoCrud.RetrieveByTdCorreo<Usuario>(usu.emailUsuario);
            if (respuesta == null)
            {
                Usuario respuestaNull = new Usuario();
                respuestaNull.contraseñaUsuario = "incorrect";
                return respuestaNull;
            }

            if (respuesta.emailUsuario.Equals(usu.emailUsuario))
            {
                return respuesta;

            }
            else
            {
                respuesta.emailUsuario = "incorrect";
            }
            return respuesta;

        }

        public string modificarUsuarioContraseña(Usuario pIdUsuario)
        {
            try
            {
                UsuarioActivoCrudFactory UsuarioCrud = new UsuarioActivoCrudFactory();

                UsuarioCrud.Update(pIdUsuario);
                return "Usuario modificado con exito";
            }
            catch (Exception e)
            {
                return "Sucedio un error " + e;
            }

        }

        public string modificarUsuarioActivo(Usuario pIdUsuario)
        {
            try
            {
                UsuarioActivoCrudFactory UsuarioActivoCrud = new UsuarioActivoCrudFactory();

                UsuarioActivoCrud.Update(pIdUsuario);
                return "Usuario activado con exito";
            }
            catch (Exception e)
            {
                return "Sucedio un error " + e;
            }

        }

        public string modificarUsuario(Usuario pUsuario)
        {
            try
            {
                RegistroUsuarioCrudFactory UsuarioCrud = new RegistroUsuarioCrudFactory();

                UsuarioCrud.Update(pUsuario);
                return "Usuario modificado con exito";
            }
            catch (Exception e)
            {
                return "Sucedio un error " + e;
            }

        }

     
    }
}
