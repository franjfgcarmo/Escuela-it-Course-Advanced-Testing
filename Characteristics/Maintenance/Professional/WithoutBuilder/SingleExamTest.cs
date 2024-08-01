using FluentAssertions;

namespace Characteristics.Maintenance.Professional.WithoutBuilder;

public class SingleExamTest : ExamTest
{
    [Fact]
    public void TestSingleExamWithEmptyNameError()
    {
        Action act = () => new SingleExam("", new Rate(3.0, 0.5));
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("required"));
    }

    [Fact]
    public void TestSingleExam()
    {
        string examName = "extraordinario";
        Rate examRate = new Rate(3.0, 0.5);
        examRate.SetValue(5);
        Exam singleExam = new SingleExam(examName, examRate);
        singleExam.GetName().Should().Be(examName);
        singleExam.GetResult().Should().BeApproximately(2.5, PRECISION);
    }

    [Fact]
    public void TestIsQualifiable()
    {
        string examName = "extraordinario";
        Rate examRate = new Rate(3.0, 1.0);
        examRate.SetValue(5);
        new SingleExam(examName, examRate).IsQualifiable().Should().BeTrue();
        examRate.SetValue(2);
        new SingleExam(examName, examRate).IsQualifiable().Should().BeFalse();
    }

    [Fact]
    public void TestGetResult()
    {
        string examName = "extraordinario";
        Rate examRate = new Rate(3.0, 1.0);
        examRate.SetValue(5);
        new SingleExam(examName, examRate).GetResult().Should().BeApproximately(5.0, PRECISION);
    }
}