using FluentAssertions;

namespace Characteristics.Risk.NeverFailingTest.V1;

public class EnvironmentTest
{
    [Fact]
    public void IncludeForMissingResourceFails() 
    {
        try 
        {
            new Environment().Include("somethingthatdoesnotexist");
          
        } 
        catch (ArgumentException exception)
        {
            exception.Message.Should().Contain("somethingthatdoesnotexist");
        }
    }
}