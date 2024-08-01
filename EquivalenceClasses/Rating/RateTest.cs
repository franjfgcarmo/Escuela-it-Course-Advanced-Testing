namespace EquivalenceClasses.Rating;

public class RateTest
{
    [Fact]
    public void TestRateWithLessThanMinimumError()
    {
        Action act = () => new RateBuilder().Minimum(-1).Build();
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("Minimum"));
    }

    [Fact]
    public void TestRateWithGreaterThanMinimumError()
    {
        Action act = () => new RateBuilder().Minimum(14).Build();
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("Minimum"));
    }

    [Fact]
    public void TestRateWithLessThanPercentError()
    {
        Action act = () => new RateBuilder().Percent(-0.1).Build();
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("Percent"));
    }

    [Fact]
    public void TestRateWithGreaterThanPercentError()
    {
        Action act = () => new RateBuilder().Percent(1.3).Build();
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("Percent"));
    }
    
    [Fact]
    public void TestIsQualifiable()
    {
        new RateBuilder().Minimum(3).Value(5).Build().IsQualifiable().Should().BeTrue();
        new RateBuilder().Minimum(3).Value(2).Build().IsQualifiable().Should().BeFalse();
    }
    
    [Fact]
    public void TestGetResultNotIsQualifiable()
    {
        Action act = () => new RateBuilder().Minimum(5).Value(4).Build().GetResult();
        act.Should().Throw<InvalidOperationException>().Where(w => w.Message.Contains("qualifiable"));
    }
    
    [Fact]
    public void TestGetResult()
    {
        new RateBuilder().Percent(0.3).Value(5.0).Build().GetResult().Should().Be(1.5);
    }
}