using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Account
    {

        public double Balance { get; set; }
        //public double Change { get; set; }
        public Account()
        {
            Balance = 0;
            //Change = 0;
        }
    }
}
