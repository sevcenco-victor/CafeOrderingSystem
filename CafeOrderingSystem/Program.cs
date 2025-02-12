using CafeOrderingSystem.Abstractions;
using CafeOrderingSystem.Services;

namespace CafeOrderingSystem;

class Program
{
    static void Main(string[] args)
    {
        ICafeService cafeService = new CafeService();
        IOrderService orderService = new OrderService(cafeService);

        while (true)
        {
            cafeService.ShowMenu();
            Console.WriteLine();
            Console.WriteLine("Enter the name of the dish you would like to order (or exit to quit): ");
            var userInput = Console.ReadLine()?.Trim();

            if (userInput?.ToLower() == "exit")
                break;

            var response = orderService.PlaceOrder(userInput ?? string.Empty);
            Console.WriteLine(response);
        }
    }
}