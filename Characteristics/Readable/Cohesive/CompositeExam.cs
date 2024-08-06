namespace Characteristics.Readable.Cohesive;

/// <summary>
/// programación: min:5 per: 100% not: 5.9
/// teoría min: 7 per:30% not: 8
/// practica min:4 per: 70% not: 5
/// 
/// programación: min:5 per: 100% not: NotQ
/// teoría min: 7 per:30% not: 6 => notQ
/// practica min:4 per: 70% not: 8
/// </summary>
public class CompositeExam : Exam
{
    private Dictionary<string, Exam> exams;

    public CompositeExam(string name, Rate rate, List<Exam> exams) : base(name, rate)
    {
        GuardCompositeExam(exams);

        this.exams = new Dictionary<string, Exam>();
        foreach (Exam exam in exams)
        {
            this.exams.Add(exam.GetName(), exam);
        }
    }

    private void GuardCompositeExam(List<Exam> exams)
    {
        ArgumentNullException.ThrowIfNull(exams);
        if (exams.Count <= 1)
        {
            throw new ArgumentException("Exams list must contain at least 2 exams");
        }

        if (TotalPercent(exams) != 1.0)
        {
            throw new ArgumentException("Total percentage of exams must be equal to 1.0");
        }

        if (!DifferentNames(exams))
        {
            throw new ArgumentException("Exam names must be unique");
        }
    }

    private bool DifferentNames(IEnumerable<Exam> exams)
    {
        var examNames = exams.Select(exam => exam.GetName()).ToList();
        examNames.Sort();
        for (var i = 0; i < examNames.Count - 1; i++)
        {
            if (examNames[i].Equals(examNames[i + 1]))
            {
                return false;
            }
        }

        return true;
    }

    private double TotalPercent(List<Exam> exams)
    {
        return exams.Sum(exam => exam.GetPercent());
    }

    public override bool IsQualifiable()
    {
        if (exams.Values.Any(exam => !exam.IsQualifiable()))
        {
            return false;
        }

        double value = exams.Values.Sum(exam => exam.GetResult());
        Rate.SetValue(value);
        return Rate.IsQualifiable();
    }
}