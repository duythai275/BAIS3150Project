using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3150Project.Domain
{
    public class Sale
    {
        public int SaleNumber { get; set; }
        public string SaleDate { get; set; }
        public string SalePerson { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GST { get; set; }
        public decimal Total { get; set; }
        public Customer Customer { get; set; }
        public List<SaleItem> SaleItems { get; set; }
    }
}
