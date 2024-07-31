using FluentAssertions;

namespace Characteristics.Risk.IncompleteTest;

public class CombinatoricsTest
{
    [Fact]
    public void TestFactorial()
    {
        Combinatorics.Factorial(0).Should().Be(1L);
        Combinatorics.Factorial(1).Should().Be(1L);
        Combinatorics.Factorial(2).Should().Be(2L);
        Combinatorics.Factorial(3).Should().Be(6L);
        Combinatorics.Factorial(4).Should().Be(24L);
    }
}