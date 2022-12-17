using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class FacturaLaboratorio: EntidadBase
    {
        public double total { get; set; }
        public double subTotal { get; set; }
        public double IVA { get; set; }
        public int mes { get; set; }
        public int idLaboratorio { get; set; }
        public string nombreLaboratorio { get; set; }

    }
}
