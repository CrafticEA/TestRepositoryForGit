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
        public DbSet<InvoicePosition> InvoicePositions => Set<InvoicePosition>();

        public ShopContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ShopDB;AttachDbFilename=C:\Users\Craftic\GitHub\ShopMVPPattern\Shop\ShopDB.mdf;Integrated Security=True;Connect Timeout=30");
            options.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                .HasMany(p => p.Products)
                .WithMany(o => o.Operations)
                .UsingEntity<InvoicePosition>(
                    j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(p => p.InvoicePositions)
                    .HasForeignKey(pt => pt.ProductId),
                    j => j
                    .HasOne(pt => pt.Operation)
                    .WithMany(p => p.InvoicePositions)
                    .HasForeignKey(pt => pt.OperationId),
                    j =>
                    {
                        //j.Property(pt => pt.Count).HasDefaultValue("Count");
                        j.HasKey(t => new { t.ProductId, t.OperationId });
                    });
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
