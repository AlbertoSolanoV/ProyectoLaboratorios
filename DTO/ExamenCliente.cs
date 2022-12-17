using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ExamenCliente: Examen 
    {
        public string nombreComercial { get; set; }
        public string nombreUsuario { get; set; }
        public DateTime horario { get; set; }
        public int idCita { get; set; }
    }
}
