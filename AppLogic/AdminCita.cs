using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminCita
    {

        public List<Citas> devolverInfoCitasLab(string pId)
        {
            CitaCrudFactory porcentajeCrud = new CitaCrudFactory();
            int id = Int32.Parse(pId);
            List<Citas> respuesta = porcentajeCrud.RetrieveByTdAll<Citas>(id);

            return respuesta;
        }

        public string cancelarCita(Citas pCita)
        {
            try
            {
                CitaCrudFactory porcentajeCrud = new CitaCrudFactory();
                porcentajeCrud.Delete(pCita);

                return "Exito, cita cancelada";
            }
            catch (Exception e)
            {
                return "Error " + e;

            }

        }
    }
}
