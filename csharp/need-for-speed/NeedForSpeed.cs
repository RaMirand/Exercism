using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class RemoteControlCar
{
    private int speed;
    private int batteryDrain;
    private int batteryLevel;
    private int totalDistance;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        this.batteryLevel = 100;
        this.totalDistance = 0;
    }

    public bool BatteryDrained()
    {
        return (batteryLevel - batteryDrain) < 0;
    }

    public int DistanceDriven()
    {
        return totalDistance;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            totalDistance += speed;
            batteryLevel -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        RemoteControlCar nitroCar = new RemoteControlCar(50,4);
        
        return nitroCar;
    }
}

class RaceTrack
{
    private int distance;
    
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.BatteryDrained() == false)
        {
            car.Drive();
            if (car.DistanceDriven() == distance) return true;
        }

        return false;
    }
}
