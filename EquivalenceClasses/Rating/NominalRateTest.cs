namespace EquivalenceClasses.Rating;

public class NominalRateTest {

   [Fact]
    //[ExpectedException(typeof(AssertionError))]
    public void TestGetNominalRateWithNegativeRateError() {
        NominalRate.GetAll(-1.1);
    }
	
   [Fact]
  //  [ExpectedException(typeof(AssertionError))]
    public void TestGetNominalRateWithExcessiveRateError() {
        NominalRate.GetAll(10.1);
    }
	
   [Fact]
    public void TestGetNominalRate() {
        NominalRate.GetAll(9.7).Should().Be(NominalRate.A);
        NominalRate.GetAll(7.7).Should().Be(NominalRate.B);
        NominalRate.GetAll(5.7).Should().Be(NominalRate.C);
        NominalRate.GetAll(3.7).Should().Be(NominalRate.D);
        NominalRate.GetAll(1.7).Should().Be(NominalRate.E);
    }

}