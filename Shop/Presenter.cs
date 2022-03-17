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
            //GetProductList();
        }

        public void AddNewClient()
        {
            model.AddClient(view.clientToAdd);
        }

        public void RemoveSelectedCLient()
        {
            model.RemoveClient(view.clientToRemove);
        }

        public void GetClientList()
        {
            view.clients = model.GetClients();
        }

        public void AddNewProduct()
        {
            model.AddClient(view.clientToAdd);
        }

        public void RemoveSelectedProduct()
        {
            model.RemoveProduct(view.productToRemove);
        }
        public void GetProductList()
        {
            view.products = model.GetProducts();
        }
    }
}
