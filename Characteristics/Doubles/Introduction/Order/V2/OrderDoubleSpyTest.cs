namespace Characteristics.Doubles.Introduction.Order.V2;

using Xunit;
using Moq;

public class OrderDoubleSpyTest
{
    private string name;
    private int amount;

    private Mock<Warehouse> warehouseMock;
    private Mock<MailService> mailService;

    public OrderDoubleSpyTest()
    {
        warehouseMock = new Mock<Warehouse>();
        mailService = new Mock<MailService>();
    }

    [Fact]
    public void TestFillingRemovesInventoryIfInStock()
    {
        name = "Talisker";
        amount = 50;
        var order = new Order(name, amount, mailService.Object);

        warehouseMock.Setup(w => w.GetInventory(name)).Returns(amount);

        order.Fill(warehouseMock.Object);

        warehouseMock.Verify(w => w.GetInventory(name), Times.Once);
        warehouseMock.Verify(w => w.Remove(name, amount), Times.Once);
        mailService.Verify(m => m.Send(It.IsAny<Message>()), Times.Never);

        Assert.True(order.IsFilled());
    }

    [Fact]
    public void TestFillingDoesNotRemoveIfNotEnoughInStock()
    {
        name = "Talisker";
        amount = 51;
        var order = new Order(name, amount, mailService.Object);

        warehouseMock.Setup(w => w.GetInventory(It.IsAny<string>())).Returns(amount - 1);

        order.Fill(warehouseMock.Object);

        warehouseMock.Verify(w => w.GetInventory(name), Times.Once);
        warehouseMock.Verify(w => w.Remove(name, amount), Times.Never);
        mailService.Verify(m => m.Send(It.IsAny<Message>()), Times.Once);

        Assert.False(order.IsFilled());
    }
}
