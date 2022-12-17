using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PaymentObject
    {
        public string Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public double Tax { get; set; }
        public double UnitAmount { get; set; }
    }
}
