using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class ShopContext : DbContext, IModel
    {
        //private static ShopContext? _shopContext;
        public DbSet<Client> Client => Set<Client>();
        public DbSet<Operation> Operation => Set<Operation>();
        public DbSet<Product> Product => Set<Product>();


        public ShopContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        //public static ShopContext GetShopContext()
        //{
        //    if(_shopContext == null)
        //    {
        //        _shopContext = new ShopContext();
        //    }
        //    return _shopContext;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Craftic\NShop1.mdf;Integrated Security=True;Connect Timeout=30");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Craftic\\Shop.mdf;Integrated Security=True;Connect Timeout=30");
            options.UseSqlServer(conn);
        }

        public void AddClient(Model.Client clientToAdd)
        {
            this.Client.Add(clientToAdd);
            this.SaveChanges();
        }

        public void RemoveClient(Client clientToRemove)
        {
            this.Client.Remove(clientToRemove);
            this.SaveChanges();
        }

        public List<Client> GetClients()
        {
            return (List<Client>)this.Client.ToList();
        }

        public void AddProduct(Product productToAdd)
        {
            this.Product.Add(productToAdd);
            this.SaveChanges();
        }

        public void RemoveProduct(Product productToRemove)
        {
            this.Product.Remove(productToRemove);
            this.SaveChanges();
        }

        public List<Product> GetProducts()
        {
            return (List<Product>)this.Product.ToList();
        }
    }
}
