using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public ICollection<Operation>? Operations { get; set; }
        public List<InvoicePosition> InvoicePositions { get; set; }
    }
}
