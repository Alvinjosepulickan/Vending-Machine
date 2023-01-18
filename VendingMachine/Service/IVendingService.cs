using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;

namespace VendingMachine.Service
{
    public interface IVendingService
    {
        void AddCoinstoAccount();
        void Menu();
        void DisplayBalance();
    }
}
