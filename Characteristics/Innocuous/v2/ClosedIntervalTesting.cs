namespace Characteristics.Innocuous.v2;

public class ClosedIntervalTesting: ClosedInterval
{
    
    private double max;
    private double min;
    public ClosedIntervalTesting(double min, double max) : base(min, max)
    {
        this.min = min;
        this.max = max;
    }
    
    // testing
    public double GetMin() {
        return min;
    }
	
    // testing
    public double GetMax() {
        return max;
    }
}