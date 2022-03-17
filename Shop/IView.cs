using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal interface IView
    {
        List<Client> clients { set; }
        Client clientToAdd { get; }
        Client clientToRemove { get; }
        List<Product> products { set; }
        Product productToAdd {get; }
        Product productToRemove { get; }

    }
}
