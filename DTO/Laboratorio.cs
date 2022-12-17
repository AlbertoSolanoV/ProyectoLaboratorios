using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Laboratorio : EntidadBase
    {
        public int idLaboratorio { get; set; }
        public string nombre { get; set; }

        public string cedulaJuridica { get; set; }

        public string nombreComercial { get; set; }

        public string razonSocial { get; set; }

        public string telefono { get; set; }
        public string paginaWeb { get; set; }

        public string email { get; set; }

        public string apartadoPostal { get; set; }

        public string permisos { get; set; }

        public string direccion { get; set; }

        public int estado { get; set; }

        public string idAdmin { get; set; }

        public string imagen1 { get; set; }
        public string imagen2 { get; set; }
        public string imagen3 { get; set; }
        public string imagen4 { get; set; }
        public string imagen5 { get; set; }

    }
}
