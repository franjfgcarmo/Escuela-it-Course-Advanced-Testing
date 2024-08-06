namespace Characteristics.Readable.Cohesive;

public class RateBuilder
{
    private double _value;
    private double _minimum;
    private double _percent;

    public RateBuilder()
    {
        _value = 0.0;
        _minimum = 0.0;
        _percent = 1.0;
    }

    public RateBuilder Value(double value)
    {
        _value = value;
        return this;
    }

    public RateBuilder Minimum(double minimum)
    {
        _minimum = minimum;
        return this;
    }

    public RateBuilder Percent(double percent)
    {
        _percent = percent;
        return this;
    }

    public Rate Build()
    {
        Rate rate = new Rate(_minimum, _percent);
        rate.SetValue(_value);
        return rate;
    }
}