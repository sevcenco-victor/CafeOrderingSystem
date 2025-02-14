namespace CafeOrderingSystem.Models;

public class Cook
{
    public string Name { get; init; }
    public const short MaxCookOrders = 5;
    private int _currentOrders;

    public int CurrentOrders
    {
        get => _currentOrders;
        private set
        {
            if (value <= MaxCookOrders)
            {
                _currentOrders = value;
            }
        }
    }

    private int _totalCookingTime;

    public Cook()
    {
    }

    public Cook(string name)
    {
        Name = name;
    }

    public void AssignOrder(Dish dish)
    {
        CurrentOrders++;
        _totalCookingTime += dish.EstimatedCookingTime;
    }

    public int GetEstimatedCookingTime() => _totalCookingTime;


    public override bool Equals(object? obj)
    {
        if (obj is Cook cook)
        {
            return Name.Equals(cook.Name)
                   && CurrentOrders == cook.CurrentOrders
                   && _totalCookingTime == cook._totalCookingTime;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }

    public override string ToString()
    {
        return $"Name: {Name} " +
               $"Estimated Cooking Time: {_totalCookingTime}" +
               $"Current Orders: {_currentOrders}";
    }
}