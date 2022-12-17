using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrdenDeCompra : EntidadBase
    {
        public int NumeroConsecutivo { get; set; }
        public int IdExamen { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCliente { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }
        public string Telefono { get; set; }
        public string NombreLab { get; set; }
        public string CedulaJuridica { get; set; }
    }
}
