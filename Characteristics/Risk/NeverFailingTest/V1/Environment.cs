namespace Characteristics.Risk.NeverFailingTest.V1;

public class Environment
{
    public void Include(string inputString)
    {
        throw new ArgumentException(inputString);
    }
}