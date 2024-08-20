namespace Characteristics.Expressive.PrimitiveAssertion.v1;

public class GrepTest
{
    private Grep grep;

    [Fact]
    public void OutputHasLineNumbers()
    {
        string content = "1st match on #1\nand\n2nd match on #3";


        string outString = grep.grep("match", "test.txt", "1st match on #1\nand\n2nd match on #3");
        Assert.True(outString.IndexOf("test.txt:1 1st match")!= -1);
        Assert.True(outString.IndexOf("test.txt:1 2nd match")!= -1);
    }
}