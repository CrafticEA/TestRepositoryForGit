using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    internal class Operation
    {
        int id;
        Client client;
        Product product;
        DateTime date;
        public Operation()
        {

        }
        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        internal Client? Client { get => client; set => client = value; }
        internal Product? Product { get => product; set => product = value; }
    }
}
