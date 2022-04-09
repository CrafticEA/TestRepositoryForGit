using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<InvoicePosition> InvoicePositions { get; set; }
    }
}
