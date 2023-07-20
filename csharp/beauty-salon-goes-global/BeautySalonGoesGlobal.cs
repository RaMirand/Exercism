using System;
using System.Globalization;
using System.Runtime.CompilerServices;
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

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => appointment
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZone = GetTimeZoneForLocationAndOs(location);

        // This method wants to verify if the IsDaylightSavingTime of the date informed is different than the IsDaylightSavingTime of 7 days ago.
        return timeZone.IsDaylightSavingTime(dt) != timeZone.IsDaylightSavingTime(dt.AddDays(-7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try
        {
            return DateTime.Parse(dtStr, location.GetCultureInfo());
        } 
        catch
        {
            return DateTime.MinValue;
        }
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

    public static CultureInfo GetCultureInfo(this Location location) =>
        location switch
        {
            Location.NewYork => CultureInfo.GetCultureInfo("en-US"),
            Location.London => CultureInfo.GetCultureInfo("en-GB"),
            Location.Paris => CultureInfo.GetCultureInfo("fr-FR"),
            _ => CultureInfo.GetCultureInfo("en-US")
        };

}
