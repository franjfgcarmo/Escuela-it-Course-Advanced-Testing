namespace EquivalenceClasses.Factorial;


public class Combinatorics
{
    public const int FactorialMaxValue = 20;

    public static long Factorial(long value)
    {
        if (value is < 0 or > FactorialMaxValue)
        {
            throw new ArgumentException($"{nameof(value)} should be between 0 and 20");
        }
        long accumulation = 1;
        for (int i = 1; i <= value; i++)
        {
            accumulation *= i;
            if (accumulation < 0)
            {
                throw new Exception();
            }
        }
        return accumulation;
    }
}