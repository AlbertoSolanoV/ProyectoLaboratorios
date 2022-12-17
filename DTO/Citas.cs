using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Citas: EntidadBase
    {
        public int  idCitas { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string horario { get; set; }
        public string nombreExamen { get; set; }

        
    }
}
