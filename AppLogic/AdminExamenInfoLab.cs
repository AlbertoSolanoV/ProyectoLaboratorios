using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminExamenInfoLab
    {
        public List<Examen> devolverInformacionExamenes(string pidExamen)
        {
            ExamenInfoLabCrudFactory listaExamenInfoLabCrud = new ExamenInfoLabCrudFactory();
            int idExamen = Int32.Parse(pidExamen);
            List<Examen> respuesta = listaExamenInfoLabCrud.RetrieveByTdAll<Examen>(idExamen);

            return respuesta;
        }

        public List<Examen> devolverInformacionTodosUsuarios()
        {
            ExamenInfoLabCrudFactory listaExamenInfoLabCrud = new ExamenInfoLabCrudFactory();
            return listaExamenInfoLabCrud.RetrieveAll<Examen>();
        }

       
    }
}
