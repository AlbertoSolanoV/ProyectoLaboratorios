using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Factura : EntidadBase
    {
        public string numeroConsecutivo { get; set; }
        public double total { get; set; }
        public double subTotal { get; set; }
        public double IVA { get; set; }
        public double descuentos { get; set; }
        public string fechaImpresion { get; set; }
        public string fechaEmision { get; set; }
        public int clave { get; set; }
        public int idOrdenCompra { get; set; }
        public string apartadoPostal { get; set; }
        public string telefono { get; set; }
        public string cedulaJuridica { get; set; }

    }
}
