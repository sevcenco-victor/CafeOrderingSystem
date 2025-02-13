namespace CafeOrderingSystem.Models;

public class Cook
{
    public string Name { get; private set; }
    public const short MAX_COOK_ORDERS = 5;
    private int _currentOrders;

    public int CurrentOrders
    {
        get => _currentOrders;
        private set
        {
            if (value <= MAX_COOK_ORDERS)
            {
                _currentOrders = value;
            }
        }
    }

    private int _totalCookingTime;


    public Cook(string name)
    {
        Name = name;
    }

    public void AssignOrder(Dish dish)
    {
        CurrentOrders++;
        _totalCookingTime += dish.EstimatedCookTime;
    }

    public int GetEstimatedCookingTime() => _totalCookingTime;
}