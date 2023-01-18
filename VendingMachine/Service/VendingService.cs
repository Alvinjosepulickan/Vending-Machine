using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;
using VendingMachine.Models;

namespace VendingMachine.Service
{
    public class VendingService: IVendingService
    {
        private Account account;
        private Product productList;
        public VendingService()
        {
            account = new Account();
            productList = new Product();
        }
        public void AddCoinstoAccount(string coin)
        {

        }
        public void SelectProduct(string productSelected)
        {
            if(productList.ProductsAvailable.ContainsKey(productSelected))
            {
                if (CheckIfUserHasSufficientBalance(productSelected))
                {
                    Console.WriteLine(productSelected);
                    Console.WriteLine(account.Balance);
                    Console.WriteLine(account.Change);
                }
            }
            else
            {
                Console.WriteLine("Please select a Valid Product");

            }
        }
        private bool CheckIfCoinIsValid(ValidCoins coin)
        {
            switch (coin)
            {
                case (ValidCoins.quarters):
                    account.Balance += 0.25;
                    break;
                case ValidCoins.dimes:
                    account.Balance += 0.1;
                    break;
                case ValidCoins.nickels:
                    account.Balance += 0.05;
                    break;
                default:
                    return false;
                    break;
            }
            return true;
        }
        private bool CheckIfUserHasSufficientBalance(string productSelected)
        {
            if (productList.ProductsAvailable[productSelected] <= account.Balance)
            {
                account.Balance -= productList.ProductsAvailable[productSelected];
                account.Change -= account.Balance;
                return true;
            }
            return false;
        }
    }
}
