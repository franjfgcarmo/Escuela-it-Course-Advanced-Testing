using FluentAssertions;

namespace Characteristics.Doubles.Introduction.Order.V2;

using System.Collections.Generic;
using Xunit;
using Moq;

public class OrderDoubleStubTest
{
    private string name;
    private int amount;

    [Fact]
    public void TestFillingRemovesInventoryIfInStock()
    {
        name = "Talisker";
        amount = 50;
        var mailService = new Mock<MailService>();
        var order = new Order(name, amount, mailService.Object);
        var warehouseMock = new Warehouse();
        warehouseMock.Add(name, amount);

        order.Fill(warehouseMock);
        order.Fill(warehouseMock);

        mailService
            .Verify(m => m
                .Send(It.IsAny<Message>()), Times.Once);

        order.IsFilled()
            .Should()
            .BeFalse();
    }

    [Fact]
    public void TestFillingDoesNotRemoveIfNotEnoughInStock()
    {
        name = "Talisker";
        amount = 51;
        var mailService = new Mock<MailService>();
        var order = new Order(name, amount, mailService.Object);
        var warehouseMock = new Mock<Warehouse>();
        warehouseMock.Setup(w => w.GetInventory(It.IsAny<string>())).Returns(amount - 1);

        var messageList = new List<Message>();
        mailService
            .Setup(m => m
                .Send(It.IsAny<Message>()))
            .Callback<Message>(msg => messageList.Add(msg));

        order.Fill(warehouseMock.Object);

        Assert.False(order.IsFilled());
        Assert.Single(messageList);
    }
}