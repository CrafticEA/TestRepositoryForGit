using Shop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для AddOperation.xaml
    /// </summary>
    public partial class AddOperation : Window, IAddOperationView
    {
        public Operation operation { get; set; }
        public ICollection<Product> products { set => ProductToAddDG.ItemsSource = value; }
        public ObservableCollection<InvoicePosition> invoicePositions { get; set; }

        AddOperationPresenter presenter;

        public AddOperation(MainWindow window)
        {
            InitializeComponent();
            presenter = new AddOperationPresenter(this);
            invoicePositions = new ObservableCollection<InvoicePosition>();
            ProductListToBuyDG.ItemsSource = invoicePositions;
            var a = (Client)window.ClientDGrid.SelectedItem;
            operation = new Operation() { InvoicePositions = invoicePositions, ClientId = a.Id };
        }


        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var p = (Product)ProductToAddDG.SelectedItem;
            var inv = new InvoicePosition() { Count = 10, Operation = operation, Product = p };
            presenter.AddInvoicePosition(inv);
        }

        private void CreateOperation_Click(object sender, RoutedEventArgs e)
        {
            operation.Date = DateTime.Now;
            presenter.CreateOperation(operation);
            this.Close();
        }
    }
}
