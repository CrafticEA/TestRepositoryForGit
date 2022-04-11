using Shop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class AddOperationPresenter
    {
        IModel model;
        IAddOperationView view;

        public AddOperationPresenter(IAddOperationView view)
        {
            this.view = view;
            model = new ShopContext();
            GetProductList();
        }

        public void GetProductList()
        {
            view.products = model.GetProducts();
        }

        public void AddInvoicePosition(InvoicePosition product)
        {
            view.invoicePositions.Add(product);
        }

        public void CreateOperation(Operation operation)
        {
            model.CreateOperation(operation);
        }
    }
}
