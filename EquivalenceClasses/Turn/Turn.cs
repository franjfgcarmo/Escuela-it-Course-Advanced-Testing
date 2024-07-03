namespace EquivalenceClasses.Turn;

class Turn
{
    private readonly int SIZE;
    private int value;

    public Turn(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Size must be greater than 0");
        }

        SIZE = size;
        value = RandomFrom0UntilNonInclusiveMax(size);
    }

    private int RandomFrom0UntilNonInclusiveMax(int max)
    {
        return new Random(DateTime.Now.Millisecond).Next(SIZE);
    }

    public int Next()
    {
        int result = value;
        value++;
        value %= SIZE;
        return result;
    }
}