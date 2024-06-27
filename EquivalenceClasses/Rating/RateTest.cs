// namespace EquivalenceClasses.Rating;
//
// public class RateTest
// {
//     [Fact]
//     public void TestRateWithLessThanMinimumError()
//     {
//         Assert.Throws<AssertionException>(() => new RateBuilder().Minimum(-1).Build());
//     }
//
//     [Fact]
//     public void TestRateWithGreaterThanMinimumError()
//     {
//         Assert.Throws<AssertionException>(() => new RateBuilder().Minimum(14).Build());
//     }
//
//     [Fact]
//     public void TestRateWithLessThanPercentError()
//     {
//         Assert.Throws<AssertionException>(() => new RateBuilder().Percent(-0.1).Build());
//     }
//
//     [Fact]
//     public void TestRateWithGreaterThanPercentError()
//     {
//         Assert.Throws<AssertionException>(() => new RateBuilder().Percent(1.3).Build());
//     }
//
//     [Fact]
//     public void TestIsQualifiable()
//     {
//         Assert.That(new RateBuilder().Minimum(3).Value(5).Build().IsQualifiable(), Is.True);
//         Assert.That(new RateBuilder().Minimum(3).Value(2).Build().IsQualifiable(), Is.False);
//     }
//
//     [Fact]
//     public void TestGetResultNotIsQualifiable()
//     {
//         Assert.Throws<AssertionException>(() => new RateBuilder().Minimum(5).Value(4).Build().GetResult());
//     }
//
//     [Fact]
//     public void TestGetResult()
//     {
//         Assert.That(new RateBuilder().Percent(0.3).Value(5.0).Build().GetResult(), Is.EqualTo(1.5));
//     }
// }