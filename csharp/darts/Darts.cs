using System;

public static class Darts
{
    public static int Score(double x, double y) =>
        DistanceFromCenter(x, y) switch
        {
            > 10d => 0,
            <= 10d and > 5d => 1,
            <= 5d and > 1d => 5,
            _ => 10
        };

    public static double DistanceFromCenter(double x, double y) =>
        Math.Sqrt(x * x + y * y);
}
