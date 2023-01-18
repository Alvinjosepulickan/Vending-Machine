﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Account
    {

        public decimal Balance { get; set; }
        public decimal Return { get; set; }
        public Account()
        {
            Balance = 0;
            Return = 0;
        }
    }
}
