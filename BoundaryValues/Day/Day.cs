namespace BoundaryValues.Day;

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
        if (day == null)
            throw new ArgumentNullException(nameof(day));

        var days = Enum.GetValues(typeof(Day)).Cast<int>().Select(x => x).ToArray();
        var index = Array.IndexOf(days, day);
        return (Day)days[(index + 1) % days.Length];
    }
}

