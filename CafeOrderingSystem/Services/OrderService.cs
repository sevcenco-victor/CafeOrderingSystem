using CafeOrderingSystem.Abstractions;

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
            return $"Dish not found with name: {dishName}";
        }

        var cook = _cafeService.GetAvailableCook();
        if (cook == null)
        {
            return "No cook available";
        }

        _cafeService.AssignOrderToCook(cook, dish);
        return $"Order placed!, estimated cooking finish time: ~ {cook.GetEstimatedCookingTime()} minutes";
    }
}