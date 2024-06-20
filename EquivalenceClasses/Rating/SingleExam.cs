namespace EquivalenceClasses.Rating;

public class SingleExam : Exam
{
    public SingleExam(string name, Rate rate) : base(name, rate)
    {
    }

    public SingleExam(string name) : this(name, new Rate())
    {
    }

    public override bool IsQualifiable()
    {
        return Rate.IsQualifiable();
    }
}