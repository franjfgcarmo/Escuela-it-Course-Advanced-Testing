namespace Characteristics.Expressive.PrimitiveAssertion.v3;

public class GrepTest
{
    private Grep grep;

    public GrepTest()
    {
        grep = new Grep();
    }

    [Fact]
    public void OutputHasLineNumbers()
    {
        string content = "1st xxx on #1\nand\n2nd xxx on #3";
        string pattern = "xxx";
        string fileName = "test.txt";

        string outString = grep.grep(pattern, fileName, content);
        Assert.Contains($"{fileName}:1 1st xxx on #1", outString);
        Assert.DoesNotContain($"{fileName}:2", outString);
        Assert.Contains($"{fileName}:3 2nd xxx on #3", outString);
    }
}