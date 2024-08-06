using FluentAssertions;

namespace Characteristics.Readable.SplitPersonality.V1;

public class ConfigurationTest
{
    [Fact]
    public void TestProcessArguments()
    {
        Configuration configuration;
        configuration = new Configuration();
        configuration.ProcessArguments(new string[] { });
        configuration.IsDebuggingEnabled().Should().BeFalse();
        configuration.IsWarningsEnabled().Should().BeFalse();
        configuration.IsVerbose().Should().BeFalse();
        configuration.ShouldShowVersion().Should().BeFalse();
        string fileName = "hello.txt";
        configuration.ProcessArguments(new string[] { "-f", fileName, "-v", "--version" });
        configuration.GetFileName().Should().Be(fileName);
        configuration.IsDebuggingEnabled().Should().BeFalse();
        configuration.IsWarningsEnabled().Should().BeFalse();
        configuration.IsVerbose().Should().BeTrue();
        configuration.ShouldShowVersion().Should().BeTrue();
        configuration = new Configuration();
        configuration.ProcessArguments(new string[] { "-f" });
    }
}