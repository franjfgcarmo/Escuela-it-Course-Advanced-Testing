namespace EquivalenceClasses.Rating;

public abstract class ExamTest
{
    protected static readonly double PRECISION = 0.001;

    //[Test(ExpectedException = typeof(AssertionError))]
    public void TestSingleExamWithNullNameError()
    {
        this.GetExamBuilder().Name(null).Build();
    }

  //  [Test(ExpectedException = typeof(AssertionError))]
    public void TestSingleExamWithEmptyNameError()
    {
        this.GetExamBuilder().Name("").Build();
    }

    protected abstract ExamBuilder GetExamBuilder();
}