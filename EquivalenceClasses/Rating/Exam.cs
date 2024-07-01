using System.Diagnostics;

namespace EquivalenceClasses.Rating;

public abstract class Exam
{
    protected string  ExamName;
    protected readonly Rate Rate;

    protected Exam(string examName, Rate rate)
    {
        if (string.IsNullOrWhiteSpace(examName))
        {
            throw new ArgumentException($"{nameof(ExamName)} is required");
        }

        ExamName = examName;
        Rate = rate;
    }

    public string GetName()
    {
        return ExamName;
    }

    public double GetMinimum()
    {
        return Rate.GetMinimum();
    }

    public double GetPercent()
    {
        return Rate.GetPercent();
    }

    public double GetValue()
    {
        return Rate.GetValue();
    }

    public abstract bool IsQualifiable();

    public double GetResult()
    {
        if (!IsQualifiable())
        {
            throw new InvalidOperationException("The exam is not qualifiable");
        }

        return Rate.GetResult();
    }
}