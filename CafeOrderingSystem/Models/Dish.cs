namespace CafeOrderingSystem.Models;

public class Dish
{
    public string Name { get; set; }
    public string Description { get; set; }

    public decimal Price
    {
        get => Ingredients.Sum(x => x.Price) * 1.20M;
    }

    public int EstimatedCookTime { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public Dish()
    {
    }

    public Dish(string name, string description, int estimatedCookTime,
        List<Ingredient> ingredients)
    {
        Name = name;
        Description = description;
        EstimatedCookTime = estimatedCookTime;
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        return
            $"{Name} \t {Description} \t" +
            $"{string.Join(", ", Ingredients.Select(i => i.Name))} \t" +
            $"{Price}";
    }
}