using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TipoExamen: EntidadBase
    {
        public int idTipoExamen { get; set; }
        public int idLaboratorio { get; set; }
        public string nombreTipoExamen { get; set; }
        public string descripcionTipoExamen { get; set; }
        public double precio { get; set; }
        public string parametros { get; set; }
    }
}
