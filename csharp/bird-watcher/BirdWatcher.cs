using System;
using System.Linq;
using System.Security.Principal;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        int[] lastWeek = new int[] { 0, 2, 5, 3, 7, 8, 4 };

        return lastWeek;
    }

    public int Today()
    {
        return birdsPerDay.Last();
    }

    public void IncrementTodaysCount()
    {
        int todayCount = birdsPerDay.Length - 1;
        birdsPerDay[todayCount] = birdsPerDay[todayCount] + 1;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int birds in birdsPerDay)
        {
            if (birds == 0) return true;
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int daysCount = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            daysCount += birdsPerDay[i];
        }
        return daysCount;
    }

    public int BusyDays()
    {
        int busyDayCount = 0;
        foreach (int birds in birdsPerDay)
        {
            if (birds >= 5)
            {
                busyDayCount++;
            }
        }
        return busyDayCount;
    }
}
