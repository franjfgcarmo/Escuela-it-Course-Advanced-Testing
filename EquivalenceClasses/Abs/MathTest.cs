
namespace EquivalenceClasses.Abs;

public class MathTest
{
    private const double Precision = 0.00000001;

    [Fact]
    public void TestAbs()
    {
        Math.Abs(-0.99).Should().BeApproximately(0.99, Precision);
        Math.Abs(-37.43).Should().BeApproximately(37.43, Precision);
    }
}