using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bitacora: EntidadBase
    {

        public string accion { get; set; }
        public string fecha { get; set; }
        public string nombreUsuario { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string nombreRol { get; set; }
    }
}
