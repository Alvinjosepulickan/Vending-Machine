using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;
using VendingMachine.Service;

namespace VenddingMachineTestProject
{
    public class ValidateVendingService
    {
        [Fact]
        public void ValidateAddCoinstoAccount1()
        {
            VendingService vendingService= new VendingService();

            ValidCoins coin;
            Enum.TryParse<ValidCoins>("30", out coin);
            Assert.Equal(false,vendingService.CheckIfCoinIsValid(coin));
        }
        [Fact]
        public void ValidateAddCoinstoAccount2()
        {
            VendingService vendingService = new VendingService();
            ValidCoins coin;
            Enum.TryParse<ValidCoins>("5", out coin);
            Assert.Equal(true, vendingService.CheckIfCoinIsValid(coin));
        }
        [Fact]
        public void ValidateAddCoinstoAccount3()
        {
            VendingService vendingService = new VendingService();

            ValidCoins coin;
            Enum.TryParse<ValidCoins>("10", out coin);
            Assert.Equal(true, vendingService.CheckIfCoinIsValid(coin));
        }
        [Fact]
        public void ValidateAddCoinstoAccount4()
        {
            VendingService vendingService = new VendingService();

            ValidCoins coin;
            Enum.TryParse<ValidCoins>("25", out coin);
            Assert.Equal(true, vendingService.CheckIfCoinIsValid(coin));
        }
        [Fact]
        public void ValidateUserHasBalance()
        {
            VendingService vendingService = new VendingService();
            vendingService.account.Balance = 2;
            Assert.Equal(true, vendingService.CheckIfUserHasSufficientBalance("chips"));
        }
        [Fact]
        public void ValidateUserHasBalance2()
        {
            VendingService vendingService = new VendingService();
            Assert.Equal(false, vendingService.CheckIfUserHasSufficientBalance("chips"));
        }
    }
}
