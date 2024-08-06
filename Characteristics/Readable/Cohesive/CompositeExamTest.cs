using FluentAssertions;

namespace Characteristics.Readable.Cohesive;

public class CompositeExamTest : ExamTest
{
    protected override ExamBuilder GetExamBuilder()
    {
        return GetCompositeExamBuilder();
    }

    private CompositeExamBuilder GetCompositeExamBuilder()
    {
        return new CompositeExamBuilder();
    }

    [Fact]
    public void TestCompositeExamWithNullExamsError()
    {
        Action act = () => GetCompositeExamBuilder().WithoutExams().Build();
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void TestCompositeExamWithEmptyExamsError()
    {
        Action act = () => GetCompositeExamBuilder().Build();
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void TestCompositeExamWithTotalPercentError()
    {
        Action act = () =>
            GetCompositeExamBuilder()
                .Exam(new SingleExamBuilder().Name("teoría").Percent(0.45).Build())
                .Exam(new SingleExamBuilder().Name("practica").Percent(0.45).Build())
                .Build();
        act.Should().Throw<ArgumentException>()
            .Where(w => w.Message.Contains("Total percentage of exams must be equal to 1.0"));
    }

    [Fact]
    public void TestCompositeExamWithRepeatedNamesError()
    {
        Action act = () =>
            GetCompositeExamBuilder()
                .Exam(new SingleExamBuilder().Name("problema").Percent(0.5).Build())
                .Exam(new SingleExamBuilder().Name("problema").Percent(0.5).Build())
                .Build();
        act.Should().Throw<ArgumentException>().Where(w => w.Message.Contains("Exam names must be unique"));
    }

    [Fact]
    public void TestCompositeExam()
    {
        Exam singelExam1 = assertSingleExam("teoría", 0.5, 7, 3.5);
        Exam singelExam2 = assertSingleExam("práctica", 0.5, 5, 2.5);

        var compositeExam = GetCompositeExamBuilder()
            .Exam(singelExam1)
            .Exam(singelExam2)
            .Name("asignatura")
            .Build();
        compositeExam.GetName().Should().Be("asignatura");
        compositeExam.IsQualifiable().Should().BeTrue();
        compositeExam.GetResult().Should().BeApproximately(6.0, PRECISION);
    }

    private Exam assertSingleExam(String name, double percent, double value, double result)
    {
        Exam singelExam = new SingleExamBuilder().Name(name).Percent(percent)
            .Value(value).Build();
        singelExam.GetName().Should().Be(name);
        singelExam.IsQualifiable().Should().BeTrue();
        singelExam.GetResult().Should().BeApproximately(result, PRECISION);
        return singelExam;
    }

    [Fact]
    public void TestIsQualifiable()
    {
        var qualifiables = new[]
        {
            [false, false, false],
            [false, false, true],
            [false, true, false],
            [false, true, true],
            [true, false, false],
            [true, false, true],
            [true, true, false],
            new[] { true, true, true }
        };
        var isQualifiables = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            true
        };
        qualifiables.Length
            .Should()
            .Be(isQualifiables.Length);

        for (var i = 0; i < qualifiables.Length; i++)
        {
            GetCompositeExamWithQualifiableOrNotSingleExam(qualifiables[i]).IsQualifiable().Should()
                .Be(isQualifiables[i]);
        }
    }

    private Exam GetCompositeExamWithQualifiableOrNotSingleExam(bool[] isQualifiables)
    {
        var compositeExamBuilder = new CompositeExamBuilder();
        double minimum = new Random((int)DateTime.Now.Ticks).Next(1, 10);
        for (var i = 0; i < isQualifiables.Length; i++)
        {
            var singleExamBuilder = new SingleExamBuilder()
                .Name($"examen{i}")
                .Minimum(minimum)
                .Percent(1.0 / isQualifiables.Length);
            if (isQualifiables[i])
                singleExamBuilder.Value(minimum + 1.0);
            else
                singleExamBuilder.Value(minimum - 1.0);
            compositeExamBuilder.Exam(singleExamBuilder.Build());
        }

        return compositeExamBuilder.Build();
    }

    [Fact]
    public void TestGetResult()
    {
        GetCompositeExamWithSamePercents(7.0, [9.0, 8.0, 7.0]).GetResult().Should().BeApproximately(8.0, PRECISION);
    }

    private static Exam GetCompositeExamWithSamePercents(double minimum, double[] values)
    {
        var compositeExamBuilder = new CompositeExamBuilder();
        for (var i = 0; i < values.Length; i++)
            compositeExamBuilder.Exam(new SingleExamBuilder()
                .Name($"examen{i}")
                .Minimum(minimum)
                .Percent(1.0 / values.Length)
                .Value(values[i])
                .Build());
        return compositeExamBuilder.Build();
    }
}