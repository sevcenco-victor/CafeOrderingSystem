using CafeOrderingSystem.Abstractions;
using CafeOrderingSystem.Data;
using CafeOrderingSystem.Models;

namespace CafeOrderingSystem.Services;

public class CafeService : ICafeService
{
    private readonly PriorityQueue<Cook, int> _cooksQueue = new();
    private List<Dish> Menu { get; set; }


    public CafeService(List<Dish>? menu = null)
    {
        var cooks = CookFactory.CreateCooks();

        foreach (var cook in cooks)
        {
            _cooksQueue.Enqueue(cook, 0);
        }

        Menu = menu ?? MenuDishFactory.CreateMenuDishes();
    }

    public void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 60));

        Console.WriteLine("\t Menu");

        foreach (var dish in Menu)
        {
            Console.WriteLine(dish);
        }
    }

    public Dish? GetDishByName(string dishName)
    {
        return Menu.Find(dish => dish.Name.Equals(dishName, StringComparison.InvariantCultureIgnoreCase));
    }

    public Cook? GetAvailableCook()
    {
        if (_cooksQueue.Count == 0) return null;

        var cook = _cooksQueue.Peek();

        return IsCookAvailable(cook) ? cook : null;
    }

    public bool IsCookAvailable(Cook cook)
    {
        return cook.CurrentOrders < Cook.MaxCookOrders;
    }

    public void AssignOrderToCook(Cook cook, Dish dish)
    {
        _cooksQueue.Dequeue();
        cook.AssignOrder(dish);
        _cooksQueue.Enqueue(cook, cook.CurrentOrders);
    }
}