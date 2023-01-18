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
        public void AddCoinstoAccount()
        {
            bool addCoinsToAccount;
            do
            {
                DisplayValidCoins();
                string selectedCoin = Console.ReadLine();
                ValidCoins coin;
                Enum.TryParse<ValidCoins>(selectedCoin, out coin);
                if (CheckIfCoinIsValid(coin))
                {
                    DisplayBalance();
                    Console.WriteLine(@"Add more coins to account?

                                        Y\y to add more coin.
                                        Any other key to exit");
                    string wantToContinue = Console.ReadLine();
                    addCoinsToAccount =wantToContinue.ToUpper().Equals("Y") ?  true : false;
                }
                else
                {
                    Console.WriteLine("Please insert a valid coin");
                    addCoinsToAccount = true;
                }
            } while (addCoinsToAccount);
        }
        private void DisplayValidCoins()
        {
            Console.WriteLine("-------------------------Valid coins--------------------");
            foreach (var coin in Enum.GetValues(typeof(ValidCoins)))
            {
                Console.WriteLine("{0}\t\t\t{1}",coin.ToString(),(int)coin);
            }
            Console.WriteLine("Please insert a Valid coin");

        }
        public void Menu()
        {
            DisplayMenu();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Please Select a Product from our menu");
            var productSelected = Console.ReadLine();
            if(productList.ProductsAvailable.ContainsKey(productSelected))
            {
                SelectProduct(productSelected);
            }
            else 
            {
                Console.WriteLine("You have selected an invalid product");
                Console.WriteLine("Press Y/y to select product. Any other key to exit");
                var userSelection = Console.ReadLine();
                if(userSelection.ToUpper().Equals("Y"))
                {
                    Menu();
                }
                else
                {
                    return;
                }
            }
        }
        public void DisplayMenu()
        {
            Console.WriteLine("-------------------------Menu--------------------");
            Console.WriteLine("Product\t\t\tPrice");
            foreach (var product in productList.ProductsAvailable)
            {
                Console.WriteLine("{0}\t\t\t{1}", product.Key, product.Value);
            }
        }
        public void SelectProduct(string productSelected)
        {
            if (CheckIfUserHasSufficientBalance(productSelected))
            {
                Console.WriteLine(productSelected);
                Console.WriteLine(account.Balance);
            }
            else 
            {
                Console.WriteLine("Sorry!! You don't have sufficient balance to purchase {0}",productSelected);
                Console.WriteLine("Enter Y/y to add coins to your balance. Any other key to exit");
                var userSelection = Console.ReadLine();
                if (userSelection.ToUpper().Equals("Y"))
                {
                    AddCoinstoAccount();
                    Console.WriteLine("Enter Y/y to select a product. Any other key to exit");
                    var selection= Console.ReadLine();
                    if (userSelection.ToUpper().Equals("Y"))
                        Menu();
                }
                else return;
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
                return true;
            }
            return false;
        }

        public void DisplayBalance()
        {
            Console.WriteLine("You have a balance of {0}$ in your account",this.account.Balance);
        }
    }
}
