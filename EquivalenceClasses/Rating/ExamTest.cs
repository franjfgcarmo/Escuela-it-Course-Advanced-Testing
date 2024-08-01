namespace EquivalenceClasses.Rating;

public abstract class ExamTest
{
    protected static readonly double PRECISION = 0.001;

    public void TestSingleExamWithNullNameError()
    {
        this.GetExamBuilder().Name(null).Build();
    }

    public void TestSingleExamWithEmptyNameError()
    {
        this.GetExamBuilder().Name("").Build();
    }

    protected abstract ExamBuilder GetExamBuilder();
}