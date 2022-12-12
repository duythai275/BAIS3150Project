using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3150Project.Domain
{
    public class SaleItem
    {
        public Item AItem { get; set; }
        public decimal ItemTotal { get; set; }
        public int Quantity { get; set; }
    }
}
