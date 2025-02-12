using CafeOrderingSystem.Abstractions;
using CafeOrderingSystem.Data;
using CafeOrderingSystem.Models;

namespace CafeOrderingSystem.Services;

public class CafeService : ICafeService
{
    private readonly PriorityQueue<Cook, int> _cooksQueue = new();
    private List<Dish> Menu { get; set; }


    public CafeService()
    {
        var cooks = new List<Cook>()
        {
            new Cook("Alice"),
            // new Cook("Bob"),
            // new Cook("Charlie"),
        };

        foreach (var cook in cooks)
        {
            _cooksQueue.Enqueue(cook, 0);
        }

        Menu = MenuDishFactory.CreateMenuDishes();
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

        var cook = _cooksQueue.Dequeue();

        return cook.CurrentOrders < 5 ? cook : null;
    }

    public bool IsCookAvailable()
    {
        if (_cooksQueue.Count == 0) return false;
        var cook = _cooksQueue.Dequeue();
        return cook.CurrentOrders < 5;
    }

    public void AssignOrderToCook(Cook cook, Dish dish)
    {
        cook.AssignOrder(dish);
        _cooksQueue.Enqueue(cook, cook.CurrentOrders);
    }
}