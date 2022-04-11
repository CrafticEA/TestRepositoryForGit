using Shop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal interface IAddOperationView
    {
        ObservableCollection<InvoicePosition> invoicePositions { get; set; }
        Operation operation { get; set; }
        ICollection<Product> products { set; }
    }
}
