using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
   public class AdminBitacora
    {

        public List<Bitacora> devolverInfoBitacora()
        {
            BitacoraCrudFactory porcentajeCrud = new BitacoraCrudFactory();
            List<Bitacora> respuesta = porcentajeCrud.RetrieveAll<Bitacora>();

            return respuesta;
        }

    }
}
