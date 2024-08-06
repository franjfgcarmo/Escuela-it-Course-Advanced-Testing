namespace Characteristics.Executable.Repeatable;

public class Turn: IDisposable
{
    private int currentValue;

    public Turn()
    {
        currentValue = 0;
    }

    public Color Take()
    {
        return (Color)currentValue; // Adjusted to use the current value directly
    }

    public void Change()
    {
        currentValue = (currentValue + 1) % (Enum.GetNames(typeof(Color)).Length - 1);
    }

    public string ToCustomString()
    {
        return $"Turn [value={currentValue}]";
    }

    public override string ToString()
    {
        return $"Turn [value={currentValue}]";
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}