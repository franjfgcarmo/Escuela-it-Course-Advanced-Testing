namespace EquivalenceClasses.Day;

public class DayTest
{
    [Fact]
    public void TestNext()
    {
        Day.TUESDAY.Next().Should().Be(Day.WEDNESDAY);
        Day.SUNDAY.Next().Should().Be(Day.MONDAY);
    }
}