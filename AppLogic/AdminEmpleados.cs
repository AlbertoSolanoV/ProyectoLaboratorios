using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminEmpleados
    {

        public List<EmpleadoLab> devolverEmpleadosLab(string pIdLab)
        {
            EmpleadoCrudFactory facturaCrud = new EmpleadoCrudFactory();
            int id = Int32.Parse(pIdLab);
            List<EmpleadoLab> respuesta = facturaCrud.RetrieveByTdAll<EmpleadoLab>(id);
           
            return respuesta;
        }

        public EmpleadoLab devolverLabEmpleado(string pIdEmpleado)
        {
            EmpleadoLabCrudFactory facturaCrud = new EmpleadoLabCrudFactory();
            int id = Int32.Parse(pIdEmpleado);
            EmpleadoLab respuesta = facturaCrud.RetrieveByTd<EmpleadoLab>(id);

            return respuesta;
        }
    }
}
