namespace Characteristics.Risk.NeverFailingTest.V2;

public class Environment
{
    public void Include(string inputString)
    {
        throw new ArgumentException(nameof(inputString));
    }
}