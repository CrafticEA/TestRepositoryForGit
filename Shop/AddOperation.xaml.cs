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
    public partial class AddOperation : Window
    {
        Operation operation;
        ObservableCollection<InvoicePosition> invoices;
        public AddOperation(MainWindow window)
        {
            InitializeComponent();
            operation = new Operation() { Client = (Client)window.ClientDGrid.SelectedItem};
            ProductToAddDG.ItemsSource = window.ProductDG.ItemsSource;
            invoices = new ObservableCollection<InvoicePosition>();
            ProductListToBuyDG.ItemsSource = invoices;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var a = (Product)ProductToAddDG.SelectedItem;
            invoices.Add(new InvoicePosition() { Count = 1, ProductId=a.Id, Product = a, Operation = this.operation });
        }
    }
}
