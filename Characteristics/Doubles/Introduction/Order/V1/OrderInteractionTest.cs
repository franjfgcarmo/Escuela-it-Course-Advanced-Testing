
using FluentAssertions;


namespace Characteristics.Doubles.Introduction.Order.V1;

using Moq;
using Xunit;


public class OrderInteractionTest
{
    private string name;
    private int amount;
    private Mock<Warehouse> warehouseMock;

    public OrderInteractionTest()
    {
        warehouseMock = new Mock<Warehouse>();
    }

    [Fact]
    public void TestFillingRemovesInventoryIfInStock()
    {
        name = "Talisker";
        amount = 50;
        Order order = new Order(name, amount);

        warehouseMock.Setup(w => w.GetInventory(name)).Returns(amount);

        order.Fill(warehouseMock.Object);
        
        order.IsFilled()
            .Should()
            .BeTrue();
    }

    [Fact]
    public void TestFillingDoesNotRemoveIfNotEnoughInStock()
    {
        name = "Talisker";
        amount = 51;
        Order order = new Order(name, amount);

        warehouseMock.Setup(w => w.GetInventory(name)).Returns(amount - 1);

        order.Fill(warehouseMock.Object);

        order.IsFilled()
            .Should()
            .BeFalse();
    }
}
