namespace CafeOrderingSystem.Models;

public class Ingredient
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Ingredient()
    {
    }

    public Ingredient(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}