
namespace EquivalenceClasses.Change;


public class TurnTest
{
    private Turn turn;

    [Fact]
    public void TestChange()
    {
        int size = 3;
        turn = new Turn(size);
        int loops = 2;
        var resultValues = GetResultValues(size, loops);
        IEnumerable<int> expectedValues = GetExpectedValues(size, loops, resultValues);
        resultValues.Should().BeEquivalentTo(expectedValues);
    }

    private List<int> GetResultValues(int size, int loops)
    {
        var resultValues = new List<int>();
        for (var i = 0; i < loops; i++)
        {
            for (var j = 0; j < size; j++)
            {
                resultValues.Add(turn.Next());
            }
        }

        return resultValues;
    }

    private IEnumerable<int> GetExpectedValues(int size, int loops, List<int> resultValues)
    {
        size.Should().BeGreaterThan(0);
        loops.Should().BeGreaterThan(0);
        Assert.NotNull(resultValues);
        resultValues.Count.Should().BeGreaterThan(0);
        var expectedValues = new List<int>();
        for (var i = 0; i < loops; i++)
        {
            for (var j = 0; j < size; j++)
            {
                expectedValues.Add(j);
            }
        }

        while (resultValues[0] != expectedValues[0])
        {
            expectedValues.Add(expectedValues[0]);
            expectedValues.RemoveAt(0);
        }

        return expectedValues;
    }
}