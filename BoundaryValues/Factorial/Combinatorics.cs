using System.Diagnostics;

namespace BoundaryValues.Factorial;


public class Combinatorics
{
    private const int FACTORIAL_MAX_VALUE = 20;

    public static long Factorial(long value)
    {
        Debug.Assert(0 <= value && value <= FACTORIAL_MAX_VALUE);
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