using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminExamenesSinFactura
    {

        public List<ExamenesSinFactura> devolverInfoFacturasCitas(string pId)
        {
            ExamenesSinFacturaCrudFactory examenCrud = new ExamenesSinFacturaCrudFactory();
            int id = Int32.Parse(pId);
            List<ExamenesSinFactura> respuesta = examenCrud.RetrieveAllId<ExamenesSinFactura>(id);

            return respuesta;
        }
        public List<ExamenesSinFactura> devolverInfoCitasCliente(string pId)
        {
            ExamenesSinFacturaCrudFactory examenCrud = new ExamenesSinFacturaCrudFactory();
            int id = Int32.Parse(pId);
            List<ExamenesSinFactura> respuesta = examenCrud.RetrieveAllIdCita<ExamenesSinFactura>(id);

            return respuesta;
        }
        public string crearCitaFactura(ExamenesSinFactura pExamen)
        {
            try
            {
                ExamenesSinFacturaCrudFactory examenCrud = new ExamenesSinFacturaCrudFactory();
                examenCrud.Create(pExamen);
                return "Exito, se creo la cita exitosamente";
            }catch (Exception e)
            {
                return "Error " + e;
            }



        }
    }
}
