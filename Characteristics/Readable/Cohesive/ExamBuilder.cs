namespace Characteristics.Readable.Cohesive;

public abstract class ExamBuilder
{
    protected string name;
    protected RateBuilder rateBuilder;

    protected ExamBuilder()
    {
        this.name = "examen";
        rateBuilder = new RateBuilder();
    }

    public ExamBuilder Name(string name)
    {
        this.name = name;
        return this;
    }

    public ExamBuilder Value(double value)
    {
        rateBuilder.Value(value);
        return this;
    }

    public ExamBuilder Minimum(double minimum)
    {
        rateBuilder.Minimum(minimum);
        return this;
    }

    public ExamBuilder Percent(double percent)
    {
        rateBuilder.Percent(percent);
        return this;
    }

    public abstract Exam Build();
}