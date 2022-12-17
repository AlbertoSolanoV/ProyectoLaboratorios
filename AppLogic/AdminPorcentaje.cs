using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminPorcentaje
    {

        public List<Porcentaje> devolverInfoPorcentajes()
        {
            PorcentajeCrudFactory porcentajeCrud = new PorcentajeCrudFactory();
            List<Porcentaje> respuesta = porcentajeCrud.RetrieveAll<Porcentaje>();

            return respuesta;
        }
        public string modificarPorcentaje(Porcentaje pPorcentaje)
        {
            PorcentajeCrudFactory porcentajeCrud = new PorcentajeCrudFactory();
            try
            {
                porcentajeCrud.Update(pPorcentaje);

                return "Exito, Modificado correctamente";
            }
            catch (Exception e)
            {
                return "Error " + e;

            }

        }
    }
}
