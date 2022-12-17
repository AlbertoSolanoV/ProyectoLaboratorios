using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ExamenesSinFactura : EntidadBase
    {

        public int idFactura { get; set; }
        public string nombreLab { get; set; }
        public string fechaEmision { get; set; }
        public int idLaboratorio { get; set; }
        public int idExamenOrden { get; set; }
        public string nombreExamen { get; set; }
        public int idCita { get; set; }

    }
}
