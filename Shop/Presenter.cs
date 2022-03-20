using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Presenter
    {
        IModel model;
        IView view;

        public Presenter(IView view)
        {
            this.view = view;
            model = new ShopContext();
            GetClientList();
            GetProductList();
        }

        public void AddNewClient()
        {
            model.AddClient(view.clientToAdd);
        }

        public void RemoveSelectedClient()
        {
            model.RemoveClient(view.selectedClient);
        }

        public void GetClientList()
        {
            view.clients = model.GetClients();
        }

        public void AddNewProduct()
        {
            model.AddProduct(view.productToAdd);
        }

        public void RemoveSelectedProduct()
        {
            model.RemoveProduct(view.selectedProduct);
        }
        public void GetProductList()
        {
            view.products = model.GetProducts();
        }
    }
}
