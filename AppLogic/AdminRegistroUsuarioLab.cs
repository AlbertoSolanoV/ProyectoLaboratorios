using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminRegistroUsuarioLab
    {
        public string RegistrarUsuarioLab(Usuario pUsuario)
        {
            try
            {
                RegistroUsuarrioLabCrudFactory porcentajeCrud = new RegistroUsuarrioLabCrudFactory();
                porcentajeCrud.Create(pUsuario);

                return "Exito";
            }
            catch (Exception e)
            {
                return "Error, " + e;
            }

        }
    }
}
