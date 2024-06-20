namespace EquivalenceClasses.Change;

using System;

class Turn
{
    private readonly int SIZE;
    private int value;

    public Turn(int size)
    {
        System.Diagnostics.Debug.Assert(size > 0);
        SIZE = size;
        value = RandomFrom0UntilNonInclusiveMax(size);
    }

    private int RandomFrom0UntilNonInclusiveMax(int max)
    {
        return new Random((int)DateTime.Now.Ticks).Next(SIZE);
    }

    public int Next()
    {
        var result = value;
        value++;
        value %= SIZE;
        return result;
    }
}