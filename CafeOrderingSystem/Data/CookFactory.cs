using CafeOrderingSystem.Models;

namespace CafeOrderingSystem.Data;

public static class CookFactory
{
    public static List<Cook> CreateCooks()
    {
        return new List<Cook>()
        {
            new Cook("Alice"),
            new Cook("Bob"),
            new Cook("Charlie"),
        };
    }
}