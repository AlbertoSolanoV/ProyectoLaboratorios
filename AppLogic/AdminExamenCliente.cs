using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
  public class AdminExamenCliente
    {
        public Examen devolverExamen(string idCita)
        {
            ExamenClienteCrudFactory examenCrud = new ExamenClienteCrudFactory();
            int id = Int32.Parse(idCita);
            Examen respuesta = examenCrud.RetrieveByTd<Examen>(id);

            return respuesta;
        }
    }
}
