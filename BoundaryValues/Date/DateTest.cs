namespace EquivalenceClasses.ClosedInterval;

// This code snippet is written in Java

public class DateTest
{
    [Fact]
    public void TestDateWithGreaterThanDayError()
    {
        Action act = () => new Date(29, 2, 1900);
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("day"));
    }

    [Fact]
    public void TestDateWithLessThanDayError()
    {
        Action act = () => new Date(0, 2, 2011);
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("day"));
    }

    [Fact]
    public void TestDateWithGreaterThanMonthError()
    {
        Action act = () => new Date(14, 13, 2016);
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("month"));
    }

    [Fact]
    public void TestDateWithLessThanMonthError()
    {
        Action act = () => new Date(14, 0, 2016);
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("month"));
    }

    [Fact]
    public void TestNext()
    {
         new Date(1, 1, 2043).Next().Should().Be(new Date(2, 1, 2043));
          new Date(1, 12, 2043).Next().Should().Be(new Date(2, 12, 2043));
          new Date(28, 2, 2043).Next().Should().Be(new Date(1, 3, 2043));
          new Date(30, 1, 2043).Next().Should().Be(new Date(31, 1, 2043));
          new Date(30, 12, 2043).Next().Should().Be(new Date(31, 12, 2043));
          new Date(31, 1, 2043).Next().Should().Be(new Date(1, 2, 2043));
          new Date(31, 12, 2043).Next().Should().Be(new Date(1, 1, 2044));
    }
}