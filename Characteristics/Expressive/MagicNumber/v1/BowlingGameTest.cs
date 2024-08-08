namespace Characteristics.Expressive.MagicNumber.v1;

public class BowlingGameTest
{
    private Game game;

    public BowlingGameTest()
    {
        game = new Game();
    }

    [Fact]
    public void PerfectGame()
    {
        Roll(10, 12); // magic
        Assert.Equal(300, game.Score());
    }

    private void Roll(int pins, int rolls)
    {
        // Implement your logic for rolling pins here
    }
}