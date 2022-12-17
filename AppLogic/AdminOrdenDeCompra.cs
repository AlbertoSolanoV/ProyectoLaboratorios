using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminOrdenDeCompra
    {
        //ORDEN DE COMPRA
        public string CrearOrdenDeCompra(OrdenDeCompra pOrden)
        {
            OrdenDeCompraCrudFactory pedCrud = new OrdenDeCompraCrudFactory();
            string respuesta = pedCrud.CreateRespuesta(pOrden);

            if (respuesta.Equals("Error"))
                return "Ha sucedido un error al registrar laboratorio";
            else
                return respuesta;
        }

        public OrdenDeCompra devolverInfoOrden(string pIdOrden)
        {
            InfoOrdenCrudFactory ordenCrud = new InfoOrdenCrudFactory();
            int id = Int32.Parse(pIdOrden);
            OrdenDeCompra respuesta = ordenCrud.RetrieveByTd<OrdenDeCompra>(id);

            return respuesta;
        }

        public List<OrdenDeCompra> DevolverTodasLasOrdenes()
        {

            OrdenDeCompraCrudFactory OrdenCrud = new OrdenDeCompraCrudFactory();
            return OrdenCrud.RetrieveAll<OrdenDeCompra>();
        }

        //ORDEN EXAMEN

        public string CrearOrdenExamen(OrdenExamen pOrdenExamen)
        {
            try
            {
                OrdenExamenCrudFactory pedCrud = new OrdenExamenCrudFactory();
                pedCrud.Create(pOrdenExamen);
                return "Exito";
            }
            catch (Exception e)
            {
                return "Error " + e;
            }

         ;
        }
    }
}
