namespace BoundaryValues.Day;

public class DayTest
{
    [Fact]
    public void TestNext()
    {
        Day.MONDAY.Next().Should().Be(Day.TUESDAY);
        Day.SATURDAY.Next().Should().Be(Day.SUNDAY);
        Day.SUNDAY.Next().Should().Be(Day.MONDAY);
    }
}