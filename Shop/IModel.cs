using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal interface IModel
    {
        void AddClient(Model.Client clientToAdd);
        void RemoveClient(Model.Client clientToRemove);
        List<Model.Client> GetClients();
        void AddProduct(Model.Product productToAdd);
        void RemoveProduct(Model.Product productToRemove);
        List<Model.Product> GetProducts();
        
    }
}
