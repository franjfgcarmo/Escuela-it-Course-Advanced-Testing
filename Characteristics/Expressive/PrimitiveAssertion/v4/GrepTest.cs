using FluentAssertions;

namespace Characteristics.Expressive.PrimitiveAssertion.v4;

public class GrepTest
{
    private v3.Grep grep;

    public GrepTest()
    {
        grep = new v3.Grep();
    }

    [Fact]
    public void OutputHasLineNumbers()
    {
        string content = "1st match on #1\nand\n2nd match on #3";
        string pattern = "match";
        string fileName = "test.txt";

        string outString = grep.grep(pattern, fileName, content);
        $"{fileName}:1 1st match"
            .Should()
            .Contain(outString);
        $"{fileName}:1 2nd match"
            .Should()
            .Contain(outString);
    }
}