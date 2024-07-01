namespace EquivalenceClasses.ClosedInterval;

public class Date
{
    private readonly int _day;
    private readonly int _month;
    private readonly int _year;

    private static readonly int[] DayLimit = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    private static readonly int MonthLimit = DayLimit.Length;

    public Date(int day, int month, int year)
    {
        if (!new ClosedInterval(1, MonthLimit).Includes(month))
        {
            throw new ArgumentException($"{nameof(month)} is not valid");
        }

        if (!new ClosedInterval(1, DayLimit[month - 1]).Includes(day))
        {
            throw new ArgumentException($"{nameof(day)} is not valid");
        }

        _day = day;
        _month = month;
        _year = year;
    }

    public Date Next()
    {
        int day = _day + 1;
        int month = _month;
        int year = _year;

        if (day > DayLimit[month - 1])
        {
            day = 1;
            month++;

            if (month > MonthLimit)
            {
                month = 1;
                year++;
            }
        }

        return new Date(day, month, year);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (ReferenceEquals(obj, this))
            return false;

        if (obj.GetType() != this.GetType())
            return false;
        var date = (Date)obj;

        return _day == date._day && _month == date._month && _year == date._year;
    }

    protected bool Equals(Date other)
    {
        return _day == other._day && _month == other._month && _year == other._year;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_day, _month, _year);
    }
}