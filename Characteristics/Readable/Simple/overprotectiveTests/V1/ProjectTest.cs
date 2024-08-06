using FluentAssertions;

namespace Characteristics.Readable.Simple.overprotectiveTests.V1;

public class ProjectTest
{
    private Project project;

    public ProjectTest(Project project)
    {
        this.project = project;
    }

    [Fact]
    public void TestCount()
    {
        Data data = project.GetData();
        data.Should().NotBeNull();
        data.Count().Should().Be(4);
    }
}