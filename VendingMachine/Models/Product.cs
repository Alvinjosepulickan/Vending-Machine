using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Product
    {
        public Dictionary<string, double> ProductsAvailable;
        public Product()
        {
            ProductsAvailable = new Dictionary<string, double>() { { "cola" , 1.0 },{ "chips",0.5 },{ "candy",0.65 } };

        }
    }
}
