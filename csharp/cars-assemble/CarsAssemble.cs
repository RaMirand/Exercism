using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed > 0 && speed <= 4 )
        {
            return 1;
        } else if (speed > 4 && speed <= 8 )
        {
            return 0.9;
        } else if (speed == 9)
        {
            return 0.8;
        } else if (speed == 10)
        {
            return 0.77;
        } else
        {
            return 0;
        }
        throw new NotImplementedException("Please implement the (static) AssemblyLine.SuccessRate() method");
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        int carsProducedPerHour = 221;
        return AssemblyLine.SuccessRate(speed) * (carsProducedPerHour * speed);
        throw new NotImplementedException("Please implement the (static) AssemblyLine.ProductionRatePerHour() method");
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        int carsPerMinute = Convert.ToInt32(ProductionRatePerHour(speed)) / 60;
        return carsPerMinute;
        throw new NotImplementedException("Please implement the (static) AssemblyLine.WorkingItemsPerMinute() method");
    }
}
