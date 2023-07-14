using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        if (IsDivisibleByFour(year) && (!IsDivisibleByOneHundred(year) || IsDivisibleByFourHundred(year))) return true; else return false;
    }

    private static bool IsDivisibleByFour(int year)
    {
        return year % 4 == 0;
    }

    private static bool IsDivisibleByOneHundred(int year)
    {
        return year % 100 == 0;
    }

    private static bool IsDivisibleByFourHundred(int year)
    {
        return year % 400 == 0;
    }

    //public static bool IsLeapYear(int year) => (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
}