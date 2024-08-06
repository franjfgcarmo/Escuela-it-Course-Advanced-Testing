using FluentAssertions;

namespace Characteristics.Readable.Simple.overprotectiveTests.V2;

public class ProjectTest
{
    private V1.Project project;

    public ProjectTest(V1.Project project)
    {
        this.project = project;
    }

    [Fact]
    public void TestCount()
    {
        V1.Data data = project.GetData();
        data.Count().Should().Be(4);
    }
}