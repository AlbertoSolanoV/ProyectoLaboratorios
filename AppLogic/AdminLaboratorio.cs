using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminLaboratorio
    {

        public string registrarLaboratorio(Laboratorio pLaboratorio)
        {
            LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();
            string respuesta = laboratorioCrud.CreateRespuesta(pLaboratorio);

            if (respuesta.Equals("Error"))
                return "Ha sucedido un error al registrar laboratorio";
            else
                return respuesta;


        }

        public Laboratorio devolverInfoLabAdmin(string pIdAdmin)
        {
            LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();
            int id = Int32.Parse(pIdAdmin);
            Laboratorio respuesta = laboratorioCrud.RetrieveByTd<Laboratorio>(id);

            return respuesta;
        }


        public string modificarLaboratorio(Laboratorio pLaboratorio)
        {
            try
            {
                LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();

                laboratorioCrud.Update(pLaboratorio);
                return "Laboratorio modificado con exito";
            }
            catch (Exception e){
                return "Sucedio un error " +e;
            }
        }

        public List<Laboratorio> devolverInfoLabs()
        {
            LaboratorioCrudFactory laboratorioCrud = new LaboratorioCrudFactory();
            List<Laboratorio> respuesta = laboratorioCrud.RetrieveAll<Laboratorio>();

            return respuesta;
        }
    }
}
