namespace Characteristics.Innocuous.v2;

public class ClosedInterval
{
    private double max;
    private double min;

    public ClosedInterval(double min, double max)
    {
        if (max<= min)
        {
            throw new ArgumentException("Max value is less than Min Value");
        }

        this.min = min;
        this.max = max;
    }
    
    public double GetLength()
    {
        return max - min;
    }

    public double GetMiddlePoint()
    {
        return (max + min) / 2;
    }

    public void Shift(double value)
    {
        min += value;
        max += value;
    }

    public bool Includes(double value)
    {
        return min <= value && value <= max;
    }

    public bool Includes(ClosedInterval closedInterval)
    {
        return Includes(closedInterval.min)
               && Includes(closedInterval.max);
    }

    public bool Intersected(ClosedInterval closedInterval)
    {
        return Includes(closedInterval.min)
               || Includes(closedInterval.max)
               || closedInterval.Includes(this);
    }

    public ClosedInterval Intersection(ClosedInterval closedInterval)
    {
        GuardIntesected(closedInterval);
        return new ClosedInterval(
            Math.Max(min, closedInterval.min),
            Math.Min(max, closedInterval.max));
    }

    public ClosedInterval Union(ClosedInterval closedInterval)
    {
        GuardIntesected(closedInterval);
        return new ClosedInterval(
            Math.Min(min, closedInterval.min),
            Math.Max(max, closedInterval.max));
    }

    private void GuardIntesected(ClosedInterval closedInterval)
    {
        if (Intersected(closedInterval))
        {
            throw new InvalidOperationException("The interval is intersected");
        }
    }
}