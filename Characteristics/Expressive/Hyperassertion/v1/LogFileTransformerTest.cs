namespace Characteristics.Expressive.Hyperassertion.v1;

using Xunit;

public class LogFileTransformerTest
{
    private string logFile;
    private string expectedOutput;

    public LogFileTransformerTest()
    {
        var logBuilder = new System.Text.StringBuilder();
        logBuilder.AppendLine("[2005-05-23 21:20:33] LAUNCHED");
        logBuilder.AppendLine("[2005-05-23 21:20:33] session-id###SID");
        logBuilder.AppendLine("[2005-05-23 21:20:33] user-id###UID");
        logBuilder.AppendLine("[2005-05-23 21:20:33] presentation-id###PID");
        logBuilder.AppendLine("[2005-05-23 21:20:35] screen1");
        logBuilder.AppendLine("[2005-05-23 21:20:36] screen2");
        logBuilder.AppendLine("[2005-05-23 21:21:36] screen3");
        logBuilder.AppendLine("[2005-05-23 21:21:36] screen4");
        logBuilder.AppendLine("[2005-05-23 21:22:00] screen5");
        logBuilder.AppendLine("[2005-05-23 21:22:48] STOPPED");
        logFile = logBuilder.ToString();

        var outputBuilder = new System.Text.StringBuilder();
        outputBuilder.AppendLine("session-id###SID");
        outputBuilder.AppendLine("presentation-id###PID");
        outputBuilder.AppendLine("user-id###UID");
        outputBuilder.AppendLine("started###2005-05-23 21:20:33");
        outputBuilder.AppendLine("screen1###1");
        outputBuilder.AppendLine("screen2###60");
        outputBuilder.AppendLine("screen3###0");
        outputBuilder.AppendLine("screen4###24");
        outputBuilder.AppendLine("screen5###48");
        outputBuilder.AppendLine("finished###2005-05-23 21:22:48");
        expectedOutput = outputBuilder.ToString();
    }

    [Fact]
    public void TransformationGeneratesRightStuffIntoTheRightFile()
    {
        var input = TempFile.WithSuffix(".src.log").Append(logFile);
        var output = TempFile.WithSuffix(".dest.log");
        new LogFileTransformer().Transform(input.File(), output.File());
        Assert.True(output.Exists(), "Destination file was not created");
        Assert.Equal(expectedOutput, output.Content());
    }
}