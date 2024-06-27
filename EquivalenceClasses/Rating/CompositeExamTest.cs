// namespace EquivalenceClasses.Rating;
//
// public class CompositeExamTest : ExamTest
// {
//     protected override ExamBuilder GetExamBuilder()
//     {
//         return GetCompositeExamBuilder();
//     }
//
//     private CompositeExamBuilder GetCompositeExamBuilder()
//     {
//         return new CompositeExamBuilder();
//     }
//
//     [Fact]
//     public void TestCompositeExamWithNullExamsError()
//     {
//         Assert.Throws<AssertionError>(() => GetCompositeExamBuilder().WithoutExams().Build());
//     }
//
//     [Fact]
//     public void TestCompositeExamWithEmptyExamsError()
//     {
//         Assert.Throws<AssertionError>(() => GetCompositeExamBuilder().Build());
//     }
//
//     [Fact]
//     public void TestCompositeExamWithTotalPercentError()
//     {
//         Assert.Throws<AssertionError>(() =>
//             GetCompositeExamBuilder()
//                 .Exam(new SingleExamBuilder().Name("teoría").Percent(0.45).Build())
//                 .Exam(new SingleExamBuilder().Name("practica").Percent(0.45).Build())
//                 .Build());
//     }
//
//     [Fact]
//     public void TestCompositeExamWithRepeatedNamesError()
//     {
//         Assert.Throws<AssertionError>(() =>
//             GetCompositeExamBuilder()
//                 .Exam(new SingleExamBuilder().Name("problema").Percent(0.5).Build())
//                 .Exam(new SingleExamBuilder().Name("problema").Percent(0.5).Build())
//                 .Build());
//     }
//
//     [Fact]
//     public void TestCompositeExam()
//     {
//         var compositeExam = GetCompositeExamBuilder()
//             .Exam(new SingleExamBuilder().Name("teoría").Percent(0.5).Value(7).Build())
//             .Exam(new SingleExamBuilder().Name("práctica").Percent(0.5).Value(5).Build())
//             .Name("asignatura")
//             .Build();
//         Assert.That(compositeExam.Name, Is.EqualTo("asignatura"));
//         Assert.That(compositeExam.IsQualifiable(), Is.True);
//         Assert.That(compositeExam.GetResult(), Is.EqualTo(6.0).Within(PRECISION));
//     }
//
//     [Fact]
//     public void TestIsQualifiable()
//     {
//         var qualifiables = new[]
//         {
//             [false, false, false],
//             [false, false, true],
//             [false, true, false],
//             [false, true, true],
//             [true, false, false],
//             [true, false, true],
//             [true, true, false],
//             new[] { true, true, true }
//         };
//         var isQualifiables = new bool[]
//         {
//             false,
//             false,
//             false,
//             false,
//             false,
//             false,
//             false,
//             true
//         };
//         Assert.AreEqual(qualifiables.Length, isQualifiables.Length);
//         for (var i = 0; i < qualifiables.Length; i++)
//             Assert.That(GetCompositeExamWithQualifiableOrNotSingleExam(qualifiables[i]).IsQualifiable(),
//                 Is.EqualTo(isQualifiables[i]), $"with {qualifiables[i]} and {isQualifiables[i]}");
//     }
//
//     public Exam GetCompositeExamWithQualifiableOrNotSingleExam(bool[] isQualifiables)
//     {
//         var compositeExamBuilder = new CompositeExamBuilder();
//         double minimum = new Random((int)DateTime.Now.Ticks).Next(10);
//         for (var i = 0; i < isQualifiables.Length; i++)
//         {
//             var singleExamBuilder = new SingleExamBuilder()
//                 .Name($"examen{i}")
//                 .Minimum(minimum)
//                 .Percent(1.0 / isQualifiables.Length);
//             if (isQualifiables[i])
//                 singleExamBuilder.Value(minimum + 1.0);
//             else
//                 singleExamBuilder.Value(minimum - 1.0);
//             compositeExamBuilder.Exam(singleExamBuilder.Build());
//         }
//
//         return compositeExamBuilder.Build();
//     }
//
//     [Fact]
//     public void TestGetResult()
//     {
//         Assert.That(GetCompositeExamWithSamePercents(7.0, new double[] { 9.0, 8.0, 7.0 }).GetResult(),
//             Is.EqualTo(8.0).Within(PRECISION));
//     }
//
//     private static Exam GetCompositeExamWithSamePercents(double minimum, double[] values)
//     {
//         var compositeExamBuilder = new CompositeExamBuilder();
//         for (var i = 0; i < values.Length; i++)
//             compositeExamBuilder.Exam(new SingleExamBuilder()
//                 .Name($"examen{i}")
//                 .Minimum(minimum)
//                 .Percent(1.0 / values.Length)
//                 .Value(values[i])
//                 .Build());
//         return compositeExamBuilder.Build();
//     }
// }