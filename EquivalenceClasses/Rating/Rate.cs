namespace EquivalenceClasses.Rating;

public class Rate
{
    private static readonly ClosedInterval RateInterval = new(0, 10);
        
    private double _value;
        
    private readonly double _minimum;
        
    private static readonly ClosedInterval PercentInterval = new(0, 1);
        
    private readonly double _percent;
        
    public Rate(double minimum, double percent)
    {
        if (!RateInterval.Includes(minimum))
        {
            throw new ArgumentException("Minimum value is not within the valid range.");
        }
        if (!PercentInterval.Includes(percent))
        {
            throw new ArgumentException("Percent value is not within the valid range.");
        }
        _minimum = minimum;
        _percent = percent;
    }
        
    public Rate(double percent) : this(0, percent)//no minimum
    {
    }
        
    public Rate() : this(0, 1)// normal. 100
    {
    }
        
    public double GetMinimum()
    {
        return _minimum;
    }

    public double GetPercent()
    {
        return _percent;
    }

    public void SetValue(double value)
    {
        if (!RateInterval.Includes(value))
        {
            throw new ArgumentException("Value is not within the valid range.");
        }
        _value = value;
    }
        
    public double GetValue()
    {
        return _value;
    }
        
    public bool IsQualifiable()
    {
        return _value >= _minimum;
    }
        
    public double GetResult()
    {
        if (!IsQualifiable())
        {
            throw new InvalidOperationException("Value is not qualifiable.");
        }
        return _value * _percent;
    }
}