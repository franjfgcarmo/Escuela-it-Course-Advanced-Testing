namespace EquivalenceClasses.Planet;

public enum Planet
{
    MERCURY,
    VENUS,
    EARTH,
    MARS,
    JUPITER,
    SATURN,
    URANUS,
    NEPTUNE
}

public static class PlanetExtension
{
    public static Planet Next(this Planet planet)
    {
        var planets = Enum.GetValues(typeof(Planet)).Cast<int>().Select(x => x).ToArray();

        if ((int)planet >= planets.Length - 1)
        {
            throw new Exception($"{planet.ToString()} is the last");
        }

        return (Planet)planets[(int)planet + 1];
    }
}