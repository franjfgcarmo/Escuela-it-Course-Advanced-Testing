using FluentAssertions;

namespace Characteristics.Risk.NeverFailingTest.V2;

public class EnvironmentTest
{
    [Fact]
    public void IncludeForMissingResourceFails()
    {
        Action act = () => new V1.Environment().Include("somethingthatdoesnotexist");
        act.Should().Throw<ArgumentException>().WithMessage("somethingthatdoesnotexist");
    }
}