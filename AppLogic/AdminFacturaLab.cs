using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminFacturaLab
    {
        public List<FacturaLaboratorio> devolverInfoFacturasLab()
        {
            FacturaLaboratorioCurdFactory facturaCrud = new FacturaLaboratorioCurdFactory();
            List<FacturaLaboratorio> respuesta = facturaCrud.RetrieveAll<FacturaLaboratorio>();
            List<FacturaLaboratorio> respuestaMeses = new List<FacturaLaboratorio>();
            double totalMes = 0;
            int cantidad = 0;
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 0; j < respuesta.Count(); j++)
                {
                    if (respuesta[j].mes == i)
                    {
                        totalMes += respuesta[j].total;
                        cantidad++;
                    }

                }
                if (totalMes != 0)
                {
                    FacturaLaboratorio factura = new FacturaLaboratorio
                    {
                        mes = i,
                        total = totalMes,
                        id = cantidad
                    };
                    respuestaMeses.Add(factura);
                }

                totalMes = 0;
                cantidad = 0;
            }

            return respuestaMeses;
        }

        public string RegistrarFactura(FacturaLaboratorio pFactura)
        {
            try
            {
                FacturaLaboratorioCurdFactory facturaCrud = new FacturaLaboratorioCurdFactory();
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
