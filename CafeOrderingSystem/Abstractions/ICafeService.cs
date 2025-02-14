using CafeOrderingSystem.Models;

namespace CafeOrderingSystem.Abstractions;

public interface ICafeService
{
    void ShowMenu();
    Dish? GetDishByName(string dishName);
    Cook? GetAvailableCook();
    bool IsCookAvailable(Cook cook);
    void AssignOrderToCook(Cook cook, Dish dish);
}