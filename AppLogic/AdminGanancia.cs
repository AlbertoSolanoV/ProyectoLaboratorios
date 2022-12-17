using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
   public class AdminGanancia
    {
        public List<Ganancias> devolverInfoGanancia(string pId)
        {
            GananciaCrudFactory porcentajeCrud = new GananciaCrudFactory();
            var id = Int32.Parse(pId);
            List<Ganancias> respuesta = porcentajeCrud.RetrieveByTdAll<Ganancias>(id);
            List<Ganancias> respuestaMeses = new List<Ganancias>();

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
                    Ganancias ganancia = new Ganancias
                    {
                        mes = i,
                        total = totalMes,
                        cantidad = cantidad
                    };
                    respuestaMeses.Add(ganancia);
                }

                totalMes = 0;
                cantidad = 0;
            }

            return respuestaMeses;

        }
    }
}
