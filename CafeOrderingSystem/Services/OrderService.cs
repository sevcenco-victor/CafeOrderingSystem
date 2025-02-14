using CafeOrderingSystem.Abstractions;
using CafeOrderingSystem.Models;

namespace CafeOrderingSystem.Services;

public class OrderService : IOrderService
{
    private readonly ICafeService _cafeService;

    public OrderService(ICafeService cafeService)
    {
        _cafeService = cafeService;
    }

    public string PlaceOrder(string dishName)
    {
        var dish = _cafeService.GetDishByName(dishName);
        if (dish == null)
        {
            return DishErrors.DishNotFound(dishName);
        }

        var cook = _cafeService.GetAvailableCook();
        if (cook == null)
        {
            return CookErrors.CookIsNotAvailable();
        }

        _cafeService.AssignOrderToCook(cook, dish);
        return $"\nOrder placed!, estimated cooking finish time: ~ {cook.GetEstimatedCookingTime()} minutes";
    }
}