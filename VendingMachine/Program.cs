// See https://aka.ms/new-console-template for more information
using VendingMachine.Enums;
using VendingMachine.Service;

Console.WriteLine("Welcome");
IVendingService vendingService = new VendingService();
bool start = true;
do
{
    vendingService.AddCoinstoAccount();
    vendingService.Menu();
} while (start);
Console.WriteLine("Thanks For Coming");
