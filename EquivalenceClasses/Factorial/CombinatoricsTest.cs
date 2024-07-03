namespace EquivalenceClasses.Factorial;

public class CombinatoricsTest
{
    [Fact]
    public void TestFactorialWithNegativeValueExceptionrror()
    {
        Action act = () => Combinatorics.Factorial(-5);
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("should be between 0 and 20"));
    }

    [Fact]
    public void TestFactorialWithMaxValueExceptionrror()
    {
        Action act = () =>  Combinatorics.Factorial(Combinatorics.FactorialMaxValue + 1);
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("should be between 0 and 20"));
    }

    [Fact]
    public void TestFactorial()
    {
        Combinatorics.Factorial(0).Should().Be(1L);
        Combinatorics.Factorial(1).Should().Be(1L);
    }

    [Fact]
    public void CalulateFactorialMaxValue()
    {
        long max = long.MaxValue;
        long min = 0;
        long average = Average(max, min);
        bool isStable;
        do
        {
            isStable = IsStable(average, max, min);
            try
            {
                Console.Write(average + " entre [" + min + ", " + max + "] con ... ");
                Console.Write(Combinatorics.Factorial(average));
                if (!isStable)
                {
                    Console.WriteLine(" A por más");
                    min = average;
                }
            }
            catch (Exception ex)
            {
                if (!isStable)
                {
                    Console.WriteLine("Un poco menos");
                    max = average;
                }
            }
            finally
            {
                average = Average(max, min);
            }
        } while (!isStable);
    }

    private static long Average(long max, long min)
    {
        return min + (max - min) / 2;
    }

    private static bool IsStable(long average, long max, long min)
    {
        return (average == min || average == max);
    }
}