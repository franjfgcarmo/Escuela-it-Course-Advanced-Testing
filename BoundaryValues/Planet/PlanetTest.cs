namespace BoundaryValues.Planet;

public class PlanetTest
{
    [Fact]
    public void TestNextWithLastError()
    {
        Action act = () => LastPlanet().Next();
        act.Should().Throw<Exception>().Where(w=> w.Message.Contains("last"));
    }

    private static Planet LastPlanet()
    {
        return (Planet)Enum.GetValues(typeof(Planet)).Cast<int>().Select(x => x).ToArray().Last();
        
    }

    [Fact]
    public void TestNext()
    {
        Planet.EARTH.Next().Should().Be(Planet.MARS);
    }
}