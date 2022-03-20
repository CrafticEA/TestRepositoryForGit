using Shop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public interface IView
    {
        List<Client> clients { set; }
        Client clientToAdd { get;}
        Client selectedClient { get; }
        List<Product> products { set; }
        Product productToAdd { get;}
        Product selectedProduct { get; }

    }
}
