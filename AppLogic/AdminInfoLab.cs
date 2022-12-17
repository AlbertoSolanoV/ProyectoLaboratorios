using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminInfoLab
    {
        public Laboratorio devolverInfoLab(string pidLaboratorio)
        {
            InfoLabCrudFactory labCrud = new InfoLabCrudFactory();
            int idLaboratorio = Int32.Parse(pidLaboratorio);
            Laboratorio respuesta = labCrud.RetrieveByTd<Laboratorio>(idLaboratorio);

            return respuesta;
        }
    }
}
