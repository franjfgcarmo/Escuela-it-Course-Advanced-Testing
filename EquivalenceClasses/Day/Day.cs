namespace EquivalenceClasses.Day;

public enum Day
{
    MONDAY,
    TUESDAY,
    WEDNESDAY,
    THURSDAY,
    FRIDAY,
    SATURDAY,
    SUNDAY
}

public  static class DayExtension{
    public static Day Next(this Day day)
    {
        var days = Enum.GetValues(typeof(Day)).Cast<int>().Select(x => x).ToArray();
        var index = Array.IndexOf(days, (int)day);
        return (Day)days[(index + 1) % days.Length];
    }
}

