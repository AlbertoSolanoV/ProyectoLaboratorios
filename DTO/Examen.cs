using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Examen : EntidadBase
    {
        public int idExamen { get; set; }
        public string nombreExamen { get; set; }
        public bool estadoExamen { get; set; }
        public double precioExamen { get; set; }
        public string parametros { get; set; }
        public string descripcionExamen { get; set; }
        public string tipoExamen { get; set; }
        public string valores { get; set; }
        public int idlaboratorio { get; set; }
        public int idTipoExamen { get; set; }
    }
}