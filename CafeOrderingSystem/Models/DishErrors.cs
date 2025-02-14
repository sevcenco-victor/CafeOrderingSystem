namespace CafeOrderingSystem.Models;

public sealed class DishErrors
{
    public static string DishNotFound(string dishName) => $"Dish not found with name: {dishName}";
}