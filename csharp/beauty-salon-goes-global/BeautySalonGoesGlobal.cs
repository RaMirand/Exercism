using System;
using System.Runtime.InteropServices;
using Xunit.Sdk;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime dateTimeScheduled = DateTime.Parse(appointmentDateDescription,
                                                    System.Globalization.CultureInfo.InvariantCulture);

        TimeZoneInfo timeZone = GetTimeZoneForLocationAndOs(location);

        DateTime targetTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeScheduled, timeZone);

        return targetTime;
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        DateTime alertTime = new DateTime();

        switch (alertLevel)
        {
            case AlertLevel.Early:
                alertTime = appointment.AddDays(-1);
                break;
            case AlertLevel.Standard:
                alertTime = appointment.AddHours(-1).AddMinutes(-45);
                break;
            case AlertLevel.Late:
                alertTime = appointment.AddMinutes(-30);
                break;
        }
        return alertTime;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZone = GetTimeZoneForLocationAndOs(location);

        return timeZone.IsDaylightSavingTime(dt);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        TimeZoneInfo timeZone = GetTimeZoneForLocationAndOs(location);

        DateTime dateScheduled = DateTime.Parse(dtStr, System.Globalization.CultureInfo.InvariantCulture);



        throw new NotImplementedException("Please implement the (static) Appointment.NormalizeDateTime() method");
    }

    public static TimeZoneInfo GetTimeZoneForLocationAndOs(Location location)
    {
        string newYorkLocationId;
        string londonLocationId;
        string parisLocationId;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            newYorkLocationId = "Eastern Standard Time";
            londonLocationId = "GMT Standard Time";
            parisLocationId = "W. Europe Standard Time";
        } else
        {
            newYorkLocationId = "America/New_York";
            londonLocationId = "Europe/London";
            parisLocationId = "Europe/Paris";
        }

        return location switch
        {
            Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById(newYorkLocationId),
            Location.London => TimeZoneInfo.FindSystemTimeZoneById(londonLocationId),
            Location.Paris => TimeZoneInfo.FindSystemTimeZoneById(parisLocationId),
            _ => throw new ArgumentException("Invalid Location"),
        };
    }

}
