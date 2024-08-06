using FluentAssertions;

namespace Characteristics.Readable.SplitPersonality.V2;


public abstract class ConfigurationTest
{
    protected Configuration configuration;
    
    public ConfigurationTest()
    {
        configuration = new Configuration();
        configuration.ProcessArguments(GetArguments());
    }

    protected virtual string[] GetArguments()
    {
        return new string[] { };
    }
}

public class DefaultValuesConfigurationTest : ConfigurationTest
{
    [Fact]
    public void TestConfiguration()
    {
        configuration.IsDebuggingEnabled().Should().BeFalse();
        configuration.IsWarningsEnabled().Should().BeFalse();
        configuration.IsVerbose().Should().BeFalse();
        configuration.ShouldShowVersion().Should().BeFalse();
    }
}

public class CorrectValuesConfigurationTest : ConfigurationTest
{
    protected override string[] GetArguments()
    {
        return new string[] { "-f", "hello.txt", "-v", "-d", "-w", "--version" };
    }

    [Fact]
    public void TestProcessArguments()
    {
        configuration.GetFileName().Should().Be("hello.txt");
        configuration.IsDebuggingEnabled().Should().BeTrue();
        configuration.IsWarningsEnabled().Should().BeTrue();
        configuration.IsVerbose().Should().BeTrue();
        configuration.ShouldShowVersion().Should().BeTrue();
    }
}

// public class ErrorValuesConfigurationTest : ConfigurationTest
// {
//     protected override string[] GetArguments()
//     {
//         return new string[] { "-f" };
//     }
//
//     [Test]
//     [ExpectedException(typeof(InvalidArgumentException))]
//     public void MissingArgumentRaisesAnError()
//     {
//     }
// }