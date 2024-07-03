namespace EquivalenceClasses.Date;

// This code is written in Java

public class DateTest
{
    [Fact]
    public void TestDateWithGreaterThanDayError()
    {
        Action act = () => new Date(29, 2, 1900);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void TestDateWithLessThanDayError()
    {
        Action act = () => new Date(0, 2, 2011);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void TestDateWithGreaterThanMonthError()
    {
        Action act = () => new Date(14, 13, 2016);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void TestDateWithLessThanMonthError()
    {
        Action act = () => new Date(14, 0, 2016);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void TestNext()
    {
        new Date(12, 6, 1968).Next().Should().Be(new Date(13, 6, 1968));
    }
}