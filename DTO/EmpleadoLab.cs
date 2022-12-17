using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmpleadoLab : EntidadBase
    {
        public string idUsuario { get; set; }
        public string identificacionUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string emailUsuario { get; set; }
        public string telefonoUsuario { get; set; }
        public string RolUsuario { get; set; }
        public string idLaboratorio { get; set; }

    }
}
