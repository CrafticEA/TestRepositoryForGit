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
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Operation> Operations => Set<Operation>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<InvoicePosition> InvoicePositions => Set<InvoicePosition>();

        public ShopContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

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
                        j.HasKey(t => new { t.ProductId, t.OperationId });
                    });
        }

        public void AddClient(Model.Client clientToAdd)
        {
            this.Clients.Add(clientToAdd);
            this.SaveChanges();
        }

        public void RemoveClient(Client clientToRemove)
        {
            this.Clients.Remove(clientToRemove);
            this.SaveChanges();
        }

        public List<Client> GetClients()
        {
            //return (List<Client>)this.Clients.ToList();
            return this.Clients.Include(c => c.Operations).ToList();
        }

        public void AddProduct(Product productToAdd)
        {
            if (Products.Where(p => p.Name == productToAdd.Name).Any())
            {
                Product product = Products.First(p => p.Name == productToAdd.Name);
                product.Count += productToAdd.Count;
            }
            else
            {
                this.Products.Add(productToAdd);
            }
            this.SaveChanges();
        }

        public void RemoveProduct(Product productToRemove)
        {
            this.Products.Remove(productToRemove);
            this.SaveChanges();
        }

        public List<Product> GetProducts()
        {
            return (List<Product>)this.Products.ToList();
        }
    }
}
