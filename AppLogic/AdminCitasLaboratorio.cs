using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminCitasLaboratorio
    {
        public string RegistrarCitaLab(CitaLaboratorio pCitaLab)
        {
            try
            {
                CitasLabCrudFactory porcentajeCrud = new CitasLabCrudFactory();
                porcentajeCrud.Create(pCitaLab);

                return "Exito, registrado correctamente";
            }
            catch (Exception e)
            {
                return "Error " + e;
            }

        }
        public List<CitaLaboratorio> devolverInfoCitasLab(string pId)
        {
            CitasLabCrudFactory porcentajeCrud = new CitasLabCrudFactory();
            int id = Int32.Parse(pId);
            List<CitaLaboratorio> respuesta = porcentajeCrud.RetrieveAllById<CitaLaboratorio>(id);

            return respuesta;
        }

        public string EliminarCitaLab(string pIdLab)
        {
            try
            {
                CitasLabCrudFactory porcentajeCrud = new CitasLabCrudFactory();
                int id = Int32.Parse(pIdLab);
                
                porcentajeCrud.DeleteId(id);

                return "Exito, eliminado correctamente";
            }
            catch (Exception e)
            {
                return "Error " + e;
            }

        }
    }
}
