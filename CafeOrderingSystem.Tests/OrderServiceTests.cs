using CafeOrderingSystem.Abstractions;
using CafeOrderingSystem.Data;
using CafeOrderingSystem.Models;
using CafeOrderingSystem.Services;
using FluentAssertions;

namespace CafeOrderingSystem.Tests;

public class OrderServiceTests
{
    private readonly IOrderService _orderService;

    public OrderServiceTests()
    {
        ICafeService cafeService = new CafeService(MenuDishFactory.CreateMenuDishes());
        _orderService = new OrderService(cafeService);
    }

    [Theory]
    [InlineData("   ....   ")]
    [InlineData("jjjj")]
    [InlineData("invalid dish name")]
    public void PlaceOrder_InvalidDishName_ReturnNotFoundMessage(string dishName)
    {
        var result = _orderService.PlaceOrder(dishName);

        result.Should().Be(DishErrors.DishNotFound(dishName));
    }
}