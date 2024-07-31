namespace BoundaryValues.Round;

public class MathTest
{
    [Fact]
    public void TestRound()
    {
        Math.Round(-3.00).Should().Be(-3L);
        Math.Round(73.499).Should().Be(73L);
        Math.Round(-33.99).Should().Be(-34L);
         Math.Round(37.50).Should().Be(38L);
         Math.Round(110.99).Should().Be(111L);
    }
}