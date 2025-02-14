namespace CafeOrderingSystem.Models;

public class Ingredient
{
    public string Name { get; }

    private decimal _price;

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0M)
            {
                throw new ArgumentException("Price must be greater then or equal to zero");
            }

            _price = value;
        }
    }

    public Ingredient(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Ingredient ingredient)
        {
            return Name.Equals(ingredient.Name)
                   && Price == ingredient.Price;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }

    public override string ToString()
    {
        return $"{Name} -> {Price:C}";
    }
}