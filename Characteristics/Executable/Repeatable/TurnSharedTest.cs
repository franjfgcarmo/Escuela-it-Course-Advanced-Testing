namespace Characteristics.Executable.Repeatable;

[TestFixture]
public class TurnSharedTest
{
    private static Turn sharedTurn;

    [OneTimeSetUp]
    public static void SetUp()
    {
        sharedTurn = new Turn();
    }

    [Test]
    public void TestTurn()
    {
        Assert.AreEqual(Color.XS, sharedTurn.Take());
    }

    [Test]
    public void TestChange()
    {
        sharedTurn.Change();
        Assert.AreEqual(Color.OS, sharedTurn.Take());
        sharedTurn.Change();
        Assert.AreEqual(Color.XS, sharedTurn.Take());
        sharedTurn.Change();
        Assert.AreEqual(Color.OS, sharedTurn.Take());
        sharedTurn.Change();
        Assert.AreEqual(Color.XS, sharedTurn.Take());
    }
}