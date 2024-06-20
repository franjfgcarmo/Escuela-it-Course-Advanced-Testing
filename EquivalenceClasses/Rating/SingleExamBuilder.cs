namespace EquivalenceClasses.Rating;

public class SingleExamBuilder : ExamBuilder
{
    public SingleExamBuilder() : base()
    {
    }
    
    public override Exam Build()
    {
        return new SingleExam(name, rateBuilder.Build());
    }
}