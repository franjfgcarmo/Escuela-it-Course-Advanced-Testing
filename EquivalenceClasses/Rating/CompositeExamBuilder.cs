namespace EquivalenceClasses.Rating;

using System;
using System.Collections.Generic;

public class CompositeExamBuilder : ExamBuilder
{
    private List<Exam> exams;

    public CompositeExamBuilder()
    {
        exams = new List<Exam>();
    }

    public CompositeExamBuilder Exam(Exam exam)
    {
        exams.Add(exam);
        return this;
    }

    public CompositeExamBuilder WithoutExams()
    {
        exams = null;
        return this;
    }

    public override Exam Build()
    {
        return new CompositeExam(name, rateBuilder.Build(), exams);
    }
}