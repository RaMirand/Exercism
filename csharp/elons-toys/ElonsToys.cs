using System;

class RemoteControlCar
{
    private int _totalDistance;
    private int _battery;

    public RemoteControlCar()
    {
        _battery = 100;
        _totalDistance = 0;
    }

    public static RemoteControlCar Buy()
    {
        RemoteControlCar car = new RemoteControlCar();

        return car;
    }

    public string DistanceDisplay() =>
        $"Driven {_totalDistance} meters";


    public string BatteryDisplay()
    {
        if (_battery < 1) return "Battery empty";

        return $"Battery at {_battery}%";
    }

    public void Drive()
    {
        if (_battery >= 1)
        {
            _totalDistance += 20;
            _battery--;
        } else
        {
            BatteryDisplay();
        }
    }
}
