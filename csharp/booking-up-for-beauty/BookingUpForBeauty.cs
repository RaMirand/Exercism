using System;
using System.ComponentModel.DataAnnotations;

static class Appointment
{
    private static readonly int _anniversaryDay = 15;
    private static readonly int _anniversaryMonth = 9;

    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime dateScheduled = DateTime.Parse(appointmentDateDescription,
                                        System.Globalization.CultureInfo.InvariantCulture);
        return dateScheduled;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime dateNow = DateTime.Now;

        if (dateNow > appointmentDate) return true;
        return false;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        DateTime dateBeginAfternoon = new DateTime(2000, 1, 1, 12, 00, 00); 
        DateTime dateEndAfternoon = new DateTime(2000, 1, 1, 18, 00, 00);

        if (appointmentDate.Hour >= dateBeginAfternoon.Hour && appointmentDate.Hour < dateEndAfternoon.Hour) return true;
        return false;
    }

    public static string Description(DateTime appointmentDate) => $"You have an appointment on {appointmentDate}.";

    public static DateTime AnniversaryDate()
    {
        DateTime anniversaryDate = new DateTime(DateTime.Now.Year, _anniversaryMonth, _anniversaryDay, 0, 0, 0);
        return anniversaryDate;
    }
}
