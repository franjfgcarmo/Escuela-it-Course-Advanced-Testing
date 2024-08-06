using DesignPattern.Builder;
using Xunit.Abstractions;

namespace DesignPattern;

public class OrderTest
{
    private readonly ITestOutputHelper output;

    public OrderTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Test1()
    {
        var order = OrderBuilder.Empty()
            .WithNumber(4)
            .CreatedOn(DateTime.Today)
            .ShippingTo(b =>
                b.Street("street")
                    .City("city")
                    .Zip("zip")
                    .Country("country"))
            .Build();
        output.WriteLine(order.ToString());
//Combining with linq expressions
        // List<Order[]> orders = Enumerable
        //         .Range(1, 10)
        //         .Select(number => OrderBuilder.Empty()
        //             .WithNumber(number)
        //             .CreatedOn(DateTime.Today)
        //             .ShippingTo(b => b
        //                 .Street("street")
        //                 .Zip("zip")
        //                 .City("city")
        //                 .Country("country"))
        //             .Build())
        //         .Chunk(2)
        //         .ToList()
        //     ));
    }
}