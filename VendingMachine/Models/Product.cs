using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Product
    {
        public Dictionary<string, decimal> ProductsAvailable;
        public Product()
        {
            ProductsAvailable = new Dictionary<string, decimal>() { { "cola" , (decimal)1.0 },{ "chips", (decimal)0.5 },{ "candy", (decimal)0.65 } };

        }
    }
}
