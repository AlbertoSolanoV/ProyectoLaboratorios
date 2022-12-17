using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
  public  class AdminClientes
    {
        public List<Cliente> devolverClientesLab(string pIdLab)
        {
            ClienteCrduFactory clienteCrud = new ClienteCrduFactory();
            int id = Int32.Parse(pIdLab);
            List<Cliente> respuesta = clienteCrud.RetrieveByTdAll<Cliente>(id);

            return respuesta;
        }

    }
}
