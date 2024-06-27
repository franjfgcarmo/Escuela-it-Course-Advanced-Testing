// namespace EquivalenceClasses.Rating;
//
// public class NominalRateTest {
//
//    [Fact]
//     //[ExpectedException(typeof(AssertionError))]
//     public void TestGetNominalRateWithNegativeRateError() {
//         NominalRate.GetAll(-1.1);
//     }
// 	
//    [Fact]
//   //  [ExpectedException(typeof(AssertionError))]
//     public void TestGetNominalRateWithExcessiveRateError() {
//         NominalRate.GetAll(10.1);
//     }
// 	
//    [Fact]
//     public void TestGetNominalRate() {
//         Assert.That(NominalRate.GetAll(9.7), Is.EqualTo(NominalRate.A));
//         Assert.That(NominalRate.GetAll(7.7), Is.EqualTo(NominalRate.B));
//         Assert.That(NominalRate.GetAll(5.7), Is.EqualTo(NominalRate.C));
//         Assert.That(NominalRate.GetAll(3.7), Is.EqualTo(NominalRate.D));
//         Assert.That(NominalRate.GetAll(1.7), Is.EqualTo(NominalRate.E));
//     }
//
// }