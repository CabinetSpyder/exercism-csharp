class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return [0, 2, 5, 3, 7, 8, 4];
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length-1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[^1] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        bool noBirds = false;
        foreach(int birdNum in birdsPerDay){
            if(birdNum == 0){
                noBirds = true;
                break;
            }
        }

        return noBirds;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int sum = 0;
        for(int i = 0; i<numberOfDays; i ++){
            sum += birdsPerDay[i];
        }        

        return sum;
    }

    public int BusyDays()
    {
        int totalBusyDays = 0;
        foreach(int birds in birdsPerDay){
            if(birds >= 5){
                totalBusyDays++;
            }
        }
        return totalBusyDays;
    }
}
