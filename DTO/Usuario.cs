using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Usuario : EntidadBase
    {
        public string identificacionUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string emailUsuario { get; set; }
        public string telefonoUsuario { get; set; }
        public string contraseñaUsuario { get; set; }
        public string fotoPerfilUsuario { get; set; }
        public int idRolUsuario { get; set; }
        public string nombreRol { get; set; }
        public string usuarioActivo { get; set; }
        public string OTPUsuario { get; set; }
        public int idLab { get; set; }

    }
}
