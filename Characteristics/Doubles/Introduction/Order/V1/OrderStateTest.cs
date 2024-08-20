namespace Characteristics.Doubles.Introduction.Order.V1;

using Xunit;

public class OrderStateTest
{
    private const string TALISKER = "Talisker";
    private const string HIGHLAND_PARK = "Highland Park";

    private Warehouse warehouse;

    public OrderStateTest()
    {
        warehouse = new Warehouse();
        warehouse.Add(TALISKER, 50);
        warehouse.Add(HIGHLAND_PARK, 25);
    }

    [Fact]
    public void TestOrderIsFilledIfEnoughInWarehouse()
    {
        Order order = new Order(TALISKER, 50);
        order.Fill(warehouse);
        Assert.True(order.IsFilled());
        Assert.Equal(0, warehouse.GetInventory(TALISKER));
    }

    [Fact]
    public void TestOrderDoesNotRemoveIfNotEnough()
    {
        Order order = new Order(TALISKER, 51);
        order.Fill(warehouse);
        Assert.False(order.IsFilled());
        Assert.Equal(50, warehouse.GetInventory(TALISKER));
    }
}