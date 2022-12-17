using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class CitaLaboratorio:EntidadBase
    {
        public int idCita { get; set; }
        public int idLaboratorio { get; set; }
        public string horario { get; set; }
        public int estado { get; set; }

    }
}
