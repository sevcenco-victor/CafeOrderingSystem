using CafeOrderingSystem.Models;

namespace CafeOrderingSystem.Data;

public class MenuDishFactory
{
    private static List<Ingredient> CreateIngredients()
    {
        return new List<Ingredient>
        {
            new Ingredient("Cheese", 2.0M),
            new Ingredient("Bread", 1.0M),
            new Ingredient("Tomato", 1.5M),
            new Ingredient("Meat", 3.5M),
            new Ingredient("Lettuce", 1.2M)
        };
    }

    public static List<Dish> CreateMenuDishes()
    {
        var ingredients = CreateIngredients();

        return new List<Dish>
        {
            new Dish("Cheeseburger", "A juicy cheeseburger", 5,
                new List<Ingredient> { ingredients[0], ingredients[1], ingredients[3] }),
            new Dish("Salad", "Fresh vegetable salad", 8,
                new List<Ingredient> { ingredients[2], ingredients[4] })
        };
    }
}