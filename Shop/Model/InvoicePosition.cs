using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    public class InvoicePosition
    {
        public int Count { get; set; }
        public int OperationId { get; set; }
        public Operation Operation { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
