using CafeOrderingSystem.Abstractions;
using CafeOrderingSystem.Data;
using CafeOrderingSystem.Models;
using CafeOrderingSystem.Services;
using FluentAssertions;

namespace CafeOrderingSystem.Tests;

public class CafeServiceTests
{
    private readonly ICafeService _cafeService;

    public CafeServiceTests()
    {
        _cafeService = new CafeService(MenuDishFactory.CreateMenuDishes());
    }

    [Fact]
    public void GetDishByName_ValidDishName_ReturnsCorrectDish()
    {
        var menu = MenuDishFactory.CreateMenuDishes();
        var menuFirstDish = menu.FirstOrDefault();

        var result = _cafeService.GetDishByName(menuFirstDish?.Name ?? "");

        result.Should().BeEquivalentTo(menuFirstDish);
    }

    [Fact]
    public void GetAvailableCook_BusyCook_ReturnsNull()
    {
        SimulateBusyCafe();

        var result = _cafeService.GetAvailableCook();

        result.Should().BeNull();
    }

    [Fact]
    public void IsCookAvailable_BusyCook_ReturnsFalse()
    {
        var cook = new Cook("Test");

        AddMaxOrdersToCook(cook);

        _cafeService.IsCookAvailable(cook).Should().BeFalse();
    }

    [Fact]
    public void AssignOrderToCook_CookOrderNumIncrement_ReturnsIncrementedCookOrderNum()
    {
        var cook = new Cook("Mike");

        cook.AssignOrder(new Dish());

        cook.CurrentOrders.Should().Be(1);
    }

    private void SimulateBusyCafe()
    {
        while (true)
        {
            var cook = _cafeService.GetAvailableCook();
            if (cook == null) break;
            AddMaxOrdersToCook(cook);
        }
    }

    private void AddMaxOrdersToCook(Cook cook)
    {
        var mockDish = new Dish()
        {
            Name = "Test",
            Description = "Test",
            EstimatedCookingTime = 2,
            Ingredients = MenuDishFactory.CreateIngredients()
        };

        for (int i = 0; i < Cook.MaxCookOrders; i++)
        {
            _cafeService.AssignOrderToCook(cook, mockDish);
        }
    }
}