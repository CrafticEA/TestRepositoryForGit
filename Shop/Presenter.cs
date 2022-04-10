using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Presenter
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
            this.GetClientList();
        }

        public void RemoveSelectedClient()
        {
            model.RemoveClient(view.selectedClient);
            this.GetClientList();
        }

        public void GetClientList()
        {
            view.clients = model.GetClients();
        }

        public void AddNewProduct()
        {
            model.AddProduct(view.productToAdd);
            this.GetProductList();
        }

        public void RemoveSelectedProduct()
        {
            model.RemoveProduct(view.selectedProduct);
            this.GetProductList();
        }
        public void GetProductList()
        {
            view.products = model.GetProducts();
        }
    }
}
