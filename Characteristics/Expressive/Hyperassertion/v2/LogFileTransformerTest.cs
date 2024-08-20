using System.Text;

namespace Characteristics.Expressive.Hyperassertion.v2;

using System;
using Xunit;

public class LogFileTransformerTest
{
    private const string START = "2005-05-23 21:20:33";
    private const string END = "2005-05-23 21:21:37";
    private LogFile logFile;

    public LogFileTransformerTest()
    {
        logFile = new LogFile(START, END);
    }

    [Fact]
    public void OverallFileStructureIsCorrect()
    {
        var expectedOutput = new StringBuilder();
        expectedOutput.AppendLine("session-id###SID");
        expectedOutput.AppendLine("presentation-id###PID");
        expectedOutput.AppendLine("user-id###UID");
        expectedOutput.AppendLine($"started###{START}");
        expectedOutput.AppendLine($"finished###{END}");

        var transformedOutput = transform(logFile.ToString());
        Assert.Equal(expectedOutput.ToString(), transformedOutput);
    }

    [Fact]
    public void ScreenDurationsGoBetweenStartedAndFinished()
    {
        logFile.AddContent("[2005-05-23 21:20:35] screen1");
        var transformedOutput = transform(logFile.ToString());

        Assert.True(transformedOutput.IndexOf("started") < transformedOutput.IndexOf("screen1"));
        Assert.True(transformedOutput.IndexOf("screen1") < transformedOutput.IndexOf("finished"));
    }

    [Fact]
    public void ScreenDurationsAreRenderedInSeconds()
    {
        logFile.AddContent("[2005-05-23 21:20:35] screen1");
        logFile.AddContent("[2005-05-23 21:21:35] screen2");
        logFile.AddContent("[2005-05-23 21:21:36] screen3");

        var transformedOutput = transform(logFile.ToString());
        Assert.Contains("screen1###0", transformedOutput);
        Assert.Contains("screen2###61", transformedOutput);
        Assert.Contains("screen3###1", transformedOutput);
    }

    private string transform(string log)
    {
        // Implement your transformation logic here
        // For now, returning null as a placeholder
        return null;
    }
}
