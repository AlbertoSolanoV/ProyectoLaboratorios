using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminTipoExamen
    {

        public void registrarTipoExamen(TipoExamen pExamen)
        {
            TipoExamenCrudFactory examenCrud = new TipoExamenCrudFactory();
            Random rnd = new Random();
            pExamen.idTipoExamen = rnd.Next(1000);
            examenCrud.CreateRespuestaT(pExamen);
        }

        public void eliminarTipoExamen(TipoExamen id)
        {
            TipoExamenCrudFactory examenCrud = new TipoExamenCrudFactory();
            examenCrud.Delete(id);
        }


        public void modificarTipoExamen(TipoExamen pExamen)
        {
            TipoExamenCrudFactory examenCrud = new TipoExamenCrudFactory();
            examenCrud.modificarTExamen(pExamen);
        }


        public List<TipoExamen> devolverTodosTExamenes(string idCliente)
        {
            TipoExamenCrudFactory examenCrud = new TipoExamenCrudFactory();
            int id = Int32.Parse(idCliente);
            List<TipoExamen> respuesta = examenCrud.devolverTipoExamenes<TipoExamen>(id);

            return respuesta;
        }


        public TipoExamen devolverUnTExamen(string idCliente)
        {
            TipoExamenCrudFactory examenCrud = new TipoExamenCrudFactory();
            int id = Int32.Parse(idCliente);
            TipoExamen respuesta = examenCrud.RetrieveByTd<TipoExamen>(id);

            return respuesta;
        }
    }
}
