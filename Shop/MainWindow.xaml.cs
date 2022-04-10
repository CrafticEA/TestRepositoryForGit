using Shop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private readonly static string[] names = new string[] { "Александр", "Максим", "Иван", "Дмитрий", "Кирилл", "Михаил", "Андрей", "Алексей", "Владимир" };
        private readonly static string[] lastNames = new string[] { "Ли", "Чжан", "Ван", "Нгуен", "Гарсиа", "Гонсалес", "Эрнандес", "Смит", "Смирнов" };
        private readonly static string[] productNames = new string[] { "молоко", "кефир", "творог", "сметана", "сыр", "гречка", "рис", "овсянка", "манка", "мука", "дрожжи", "сахар", "соль" };
        static public Random random = new Random();
        Presenter presenter;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        public List<Client> clients { set => this.ClientDGrid.ItemsSource = value; }

        public Client clientToAdd { get; set; }

        public Client selectedClient { get; set; }

        public List<Product> products { set => this.ProductDG.ItemsSource = value; }

        public Product productToAdd { get; set; }

        public Product selectedProduct { get; set; }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            clientToAdd = new Client { FirstName = names[random.Next(0, names.Length - 1)], LastName = lastNames[random.Next(0, lastNames.Length - 1)] };
            presenter.AddNewClient();
        }

        private void RemoveClientButton_Click(object sender, RoutedEventArgs e)
        {
            selectedClient = (Client)ClientDGrid.SelectedItem;
            presenter.RemoveSelectedClient();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            productToAdd = new Product { Name = productNames[random.Next(0, productNames.Length - 1)], Price = random.Next(1, 10) * 10, Count = random.Next(5, 10) };
            presenter.AddNewProduct();
        }
        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            selectedProduct = (Product)ProductDG.SelectedItem;
            presenter.RemoveSelectedProduct();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddOperation_Click(object sender, RoutedEventArgs e)
        {
            Window d = new AddOperation(this);
            d.ShowDialog();
        }
    }
}
