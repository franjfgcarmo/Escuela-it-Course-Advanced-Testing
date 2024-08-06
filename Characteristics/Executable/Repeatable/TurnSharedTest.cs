using FluentAssertions;

namespace Characteristics.Executable.Repeatable;

public class TurnSharedTest : IClassFixture<Turn>
{
    Turn _sharedTurn;

    public TurnSharedTest(Turn fixture)
    {
        _sharedTurn = fixture;
    }

    [Fact]
    public void TestChange()
    {
        _sharedTurn.Change();
        _sharedTurn.Take().Should().Be(Color.OS);
        _sharedTurn.Change();
        _sharedTurn.Take().Should().Be(Color.XS);
        _sharedTurn.Change();
        _sharedTurn.Take().Should().Be(Color.OS);
        _sharedTurn.Change();
        _sharedTurn.Take().Should().Be(Color.XS);
    }
    
    [Fact]
    public void TestTurn()
    {
        _sharedTurn.Take().Should().Be(Color.XS);
        _sharedTurn.Change();
    }
}