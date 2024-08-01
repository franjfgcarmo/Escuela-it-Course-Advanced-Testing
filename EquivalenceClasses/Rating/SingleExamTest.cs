namespace EquivalenceClasses.Rating;

public class SingleExamTest : ExamTest
{
    protected override ExamBuilder GetExamBuilder()
    {
        return new SingleExamBuilder();
    }

    [Fact]
    public void TestSingleExam()
    {
        string name = "extraordinario";
        Exam singleExam = this.GetExamBuilder().Name(name).Minimum(3.0)
            .Percent(0.5).Value(5).Build();
        singleExam.GetName().Should().Be(name);
        singleExam.GetResult().Should().BeApproximately(2.5, PRECISION);
    }

    [Fact]
    public void TestIsQuilifiable()
    {
        GetExamBuilder().Minimum(3.0).Value(5).Build()
            .IsQualifiable().Should().BeTrue();
        GetExamBuilder().Minimum(3.0).Value(2).Build()
            .IsQualifiable().Should().BeFalse();
    }

    [Fact]
    public void TestGetResult()
    {
        GetExamBuilder().Percent(0.3).Value(5).Build()
            .GetResult().Should().BeApproximately(1.5, PRECISION);
    }
}