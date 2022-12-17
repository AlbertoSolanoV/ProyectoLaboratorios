using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ganancias:EntidadBase
    {
        public int mes { get; set; }
        public double total { get; set; }
        public int cantidad { get; set; }
    }
}
