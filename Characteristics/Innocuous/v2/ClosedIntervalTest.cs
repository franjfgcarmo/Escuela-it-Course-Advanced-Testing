using FluentAssertions;

namespace Characteristics.Innocuous.v2;

public class ClosedIntervalTest
{
    private ClosedIntervalTesting _closedInterval = null!;

    [Fact]
    public void TestClosedIntervalWithInverseError()
    {
        Action act = () => new ClosedIntervalTesting(20, -30);
        act.Should().Throw<ArgumentException>().WithMessage("Max value is less than Min Value");
    }

    [Fact]
    public void TestClosedInterval()
    {
        _closedInterval = new ClosedIntervalTesting(-20, 30);
        _closedInterval.GetMin().Should().Be(-20);
        _closedInterval.GetMax().Should().Be(30);
    }

    [Fact]
    public void TestIncludesDouble()
    {
        _closedInterval = new ClosedIntervalTesting(17, 71);
        _closedInterval.Includes(-3).Should().BeFalse();
        _closedInterval.Includes(50).Should().BeTrue();
        _closedInterval.Includes(99).Should().BeFalse();
    }


    [Fact]
    public void TestIncludesClosedInterval()
    {
        _closedInterval = new ClosedIntervalTesting(-5, 5);
        _closedInterval.Includes(new ClosedInterval(-7, -6)).Should().BeFalse();
        _closedInterval.Includes(new ClosedInterval(-7, 0)).Should().BeFalse();
        _closedInterval.Includes(new ClosedInterval(-1, 1)).Should().BeTrue();
        _closedInterval.Includes(new ClosedInterval(0, 7)).Should().BeFalse();
        _closedInterval.Includes(new ClosedInterval(7, 9)).Should().BeFalse();
    }

    [Fact]
    public void TestIntersected()
    {
        _closedInterval = new ClosedIntervalTesting(10, 20);
        _closedInterval.Intersected(new ClosedInterval(-10, 0)).Should().BeFalse();
        _closedInterval.Intersected(new ClosedInterval(5, 15)).Should().BeTrue();
        _closedInterval.Intersected(new ClosedInterval(10, 20)).Should().BeTrue();
        _closedInterval.Intersected(new ClosedInterval(15, 25)).Should().BeTrue();
        _closedInterval.Intersected(new ClosedInterval(30, 40)).Should().BeFalse();
        _closedInterval.Intersected(new ClosedInterval(0, 30)).Should().BeTrue();
    }
}