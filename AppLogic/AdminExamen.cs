using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminExamen
    {

        public void registrarExamen(Examen pExamen)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            pExamen.estadoExamen = false;
            examenCrud.CreateRespuestaE(pExamen);
        }

        public void modificarExamen(Examen pExamen)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            examenCrud.modificarExamen(pExamen);
        }

        public List<ExamenCliente> devolverExamenesCliente(string idCliente)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            int id = Int32.Parse(idCliente);
            List<ExamenCliente> respuesta = examenCrud.RetrieveAllCliente<ExamenCliente>(id);

            return respuesta;
        }
        public ExamenCliente devolverUnExamen(string idExamen)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            int id = Int32.Parse(idExamen);
            ExamenCliente respuesta = examenCrud.RetrieveByTd<ExamenCliente>(id);

            return respuesta;
        }

        public List<ExamenCliente> devolverExamenUsuarios(string idUsuario)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            int id = Int32.Parse(idUsuario);
            List<ExamenCliente> respuesta = examenCrud.RetrieveAllUsuario<ExamenCliente>(id);

            return respuesta;
        }

        public void eliminarTipoExamen(Examen id)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            examenCrud.Delete(id);
        }


    }
}
