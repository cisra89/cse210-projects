using System;
using System.Globalization;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public int GetLength()
    {
        return _length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        string date = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        string distance = GetDistance().ToString("F1", CultureInfo.InvariantCulture);
        string speed = GetSpeed().ToString("F1", CultureInfo.InvariantCulture);
        string pace = GetPace().ToString("F1", CultureInfo.InvariantCulture);

        return $"{date} {GetType().Name} ({_length} min): " +
               $"Distance: {distance} miles, " +
               $"Speed: {speed} mph, " +
               $"Pace: {pace} min per mile";
    }
}
