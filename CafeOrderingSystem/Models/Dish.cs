namespace CafeOrderingSystem.Models;

public class Dish
{
    public string Name { get; init; }

    public string Description { get; set; }

    public decimal Price
    {
        get => Ingredients.Sum(x => x.Price) * 1.20M;
    }

    private int _estimateCookingTime;

    public int EstimatedCookingTime
    {
        get => _estimateCookingTime;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Estimated cooking time cannot be less than 0");
            }

            _estimateCookingTime = value;
        }
    }

    public List<Ingredient> Ingredients { get; set; }

    public Dish()
    {
    }

    public Dish(string name, string description, int estimatedCookingTime,
        List<Ingredient> ingredients)
    {
        Name = name;
        Description = description;
        EstimatedCookingTime = estimatedCookingTime;
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        return
            $"{Name} \t {Description} \t" +
            $"{string.Join(", ", Ingredients.Select(i => i.Name))} \t" +
            $"{Price:C}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Dish dish)
        {
            return Name.Equals(dish.Name)
                   && Description.Equals(dish.Description)
                   && EstimatedCookingTime == dish.EstimatedCookingTime
                   && Ingredients.SequenceEqual(dish.Ingredients);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }
}