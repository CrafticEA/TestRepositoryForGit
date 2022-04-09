using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public ICollection<Product> Products { get; set; }
        public ObservableCollection<InvoicePosition> InvoicePositions { get; set; }
    }
}
