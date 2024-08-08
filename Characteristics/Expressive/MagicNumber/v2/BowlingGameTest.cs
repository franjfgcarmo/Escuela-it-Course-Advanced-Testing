namespace Characteristics.Expressive.MagicNumber.v2;

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
        Roll(Pins(10), Times(12)); // magic
        Assert.Equal(300, game.Score());
    }

    private static int Pins(int n) {
        return n;
    }

    private static int Times(int n) {
        return n;
    }
    
    private void Roll(int pins, int rolls)
    {
        // Implement your logic for rolling pins here
    }
}