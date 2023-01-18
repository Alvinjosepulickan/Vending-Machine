// See https://aka.ms/new-console-template for more information
using VendingMachine.Enums;
using VendingMachine.Service;

Console.WriteLine("----------------Welcome to Vending Machine-------------------------");
IVendingService vendingService = new VendingService();

bool start = true;
do
{
    vendingService.DisplayBalance();
    vendingService.AddCoinstoAccount();
    vendingService.Menu();
    vendingService.DisplayBalance();
    Console.WriteLine("Press Y/y to continue your purchase");
    var wantToContinue=Console.ReadLine();
    start=(wantToContinue.ToUpper().Equals("Y"))?true:false;
} while (start);
vendingService.DisplayBalance();
Console.WriteLine("Thanks For Coming");
