using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class OrdenExamen : EntidadBase
    {
        public int IdExamen { get; set; }
        public int IdOrdenCompra { get; set; }
    }
}
