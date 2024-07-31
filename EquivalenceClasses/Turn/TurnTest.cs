namespace EquivalenceClasses.Turn;

public class TurnTest
{
    private Turn turn;

    [Fact]
    public void TestChange()
    {
        int size = 3;
        turn = new Turn(size);
        int loops = 2;
        List<int> resultValues = GetResultValues(size, loops);
        List<int> expectedValues = GetExpectedValues(size, loops, resultValues);
       resultValues.Should().BeEquivalentTo(expectedValues);
    }

    private List<int> GetResultValues(int size, int loops)
    {
        List<int> resultValues = new List<int>();
        for (int i = 0; i < loops; i++)
        {
            for (int j = 0; j < size; j++)
            {
                resultValues.Add(turn.Next());
            }
        }
        return resultValues;
    }

    private List<int> GetExpectedValues(int size, int loops, List<int> resultValues)
    {
        List<int> expectedValues = new List<int>();
        for (int i = 0; i < loops; i++) {
            for (int j = 0; j < size; j++) {
                expectedValues.Add(j);
            }
        }
        while (resultValues[0] != expectedValues[0]) {
            expectedValues.Add(expectedValues[0]);
            expectedValues.RemoveAt(0);
        }
        return expectedValues;
    }
}