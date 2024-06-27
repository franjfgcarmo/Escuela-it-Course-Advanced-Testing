// namespace EquivalenceClasses.Rating;
//
// public class SingleExamTest : ExamTest
// {
//     protected override ExamBuilder GetExamBuilder()
//     {
//         return new SingleExamBuilder();
//     }
//     
//     [Fact]
//     public void TestSingleExam()
//     {
//         string name = "extraordinario";
//         Exam singleExam = this.GetExamBuilder().Name(name).Minimum(3.0)
//             .Percent(0.5).Value(5).Build();
//         Assert.That(singleExam.GetName(), Is.EqualTo(name));
//         Assert.That(singleExam.GetResult(), Is.EqualTo(2.5).Within(PRECISION));
//     }
//
//     [Fact]
//     public void TestIsQuilifiable()
//     {
//         Assert.That(this.GetExamBuilder().Minimum(3.0).Value(5).Build()
//             .IsQualifiable(), Is.True);
//         Assert.That(this.GetExamBuilder().Minimum(3.0).Value(2).Build()
//             .IsQualifiable(), Is.False);
//     }
//     
//     [Fact]
//     public void TestGetResult()
//     {
//         Assert.That(this.GetExamBuilder().Percent(0.3).Value(5).Build()
//             .GetResult(), Is.EqualTo(1.5).Within(PRECISION));
//     }
// }