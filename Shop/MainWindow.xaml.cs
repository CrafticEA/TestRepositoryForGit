using Shop.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        Presenter presenter;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
            //This Comment for Test Branch
            //New Test Branch Comment
            //Model.Client client = new Model.Client() { FirstName = "Ke2e24ek", LastName = "Ch12ee2eb"};
            //Model.Client client2 = new Model.Client() { FirstName = "Kee23k", LastName = "Chee38eb" };

            //using (ShopContext db = new ShopContext())
            //{
            //    db.Client.Add(client);
            //    db.Client.Add(client2);
            //    db.SaveChanges();
            //}
        }

        List<Client> IView.clients { set => this.ClientDGrid.ItemsSource = value; } 

        Client IView.clientToAdd => throw new NotImplementedException();

        Client IView.clientToRemove => throw new NotImplementedException();

        List<Product> IView.products { set => throw new NotImplementedException(); }

        Product IView.productToAdd => throw new NotImplementedException();

        Product IView.productToRemove => throw new NotImplementedException();
    }
}
