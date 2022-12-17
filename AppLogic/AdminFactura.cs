using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminFactura
    {

        public List<Factura> devolverInfoFacturas()
        {
            FacturaCrudFactory facturaCrud = new FacturaCrudFactory();
            return facturaCrud.RetrieveAll<Factura>();
        }
        public string RegistrarFactura(Factura pFactura)
        {
            try
            {
                FacturaCrudFactory facturaCrud = new FacturaCrudFactory();
                facturaCrud.Create(pFactura);
                return "Exito";
            }
            catch (Exception e)
            {
                return "Error " + e;
            }


        }
    }
}
