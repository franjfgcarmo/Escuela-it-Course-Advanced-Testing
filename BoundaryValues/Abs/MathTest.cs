namespace BoundaryValues.Abs;

public class MathTest
{
    private const double Precision = 0.00000001;

    [Fact]
    public void TestAbs()
    {
        System.Math.Abs(double.MinValue).Should().BeApproximately(-(double.MinValue + 1), Precision);
        System.Math.Abs(-0.01).Should().BeApproximately(0.01, Precision);
        System.Math.Abs(0.0).Should().BeApproximately(0.0, Precision);
        System.Math.Abs(double.MaxValue).Should().BeApproximately(double.MaxValue, Precision);
    }
}