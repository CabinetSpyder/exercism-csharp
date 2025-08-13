class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    public int _speed;
    public int _batteryDrain;
    private int _distanceDriven = 0;
    private int _batteryLeft = 100;
    public RemoteControlCar(int speed, int batteryDrain){
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        if(_batteryDrain > _batteryLeft){
            return true;
        }else{
            return false;
        }
    }

    public int DistanceDriven()
    {
        return _distanceDriven;     
    }

    public void Drive()
    {
        if(!BatteryDrained()){
            _distanceDriven += _speed;
            _batteryLeft -= _batteryDrain;
        }

    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);        
    }
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    int _distance;

    public RaceTrack(int distance){
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int batteryUses = 100/car._batteryDrain;
        if(batteryUses*car._speed >= _distance)
        {
            return true;
        }else
        {
            return false;
        }
    }
}
