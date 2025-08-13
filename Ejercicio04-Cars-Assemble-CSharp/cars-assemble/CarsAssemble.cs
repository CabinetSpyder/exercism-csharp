static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if(speed == 0){
            return 0.0;
        }else if(speed >= 1 && speed <= 4){
            return 1.0;
        }else if(speed > 4 && speed <= 8){
            return 0.9;
        }else if(speed == 9){
            return 0.8;
        }else{
            return 0.77;
        }
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        //Cars per hour 221 at speed 1. Linear increase
        return speed * 221 * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)ProductionRatePerHour(speed) / 60;        
    }
}
