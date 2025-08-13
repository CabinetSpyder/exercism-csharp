// TODO implement the IRemoteControlCar interface
public interface IRemoteControlCar
{
    public void Drive();
    public int DistanceTravelled{get;}
}

public class ProductionRemoteControlCar: IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int CompareTo(ProductionRemoteControlCar? other)
    {
        if( other == null) return 1;

        //CompareTo(other.NumberOfVictories) llama al CompareTo del tipo de dato de NumberOfVictories(int)
        //Devuelve <0 si el NumberOfVictories de this es menor que other, >0 si es mayor y 0 si son iguales
        return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }

    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar: IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        //Orden ascendente de victorias, el mejor se introduce el ultimo.
        /*List<ProductionRemoteControlCar> result = [];
        if(prc1.CompareTo(prc2) >=0){
            result.Add(prc2);
            result.Add(prc1);
        }else if(prc1.CompareTo(prc2) < 0)
        {
            result.Add(prc1);
            result.Add(prc2);

        }
        return result;
        */
        List<ProductionRemoteControlCar> result = [prc1, prc2];
        result.Sort();
        
        return result;
    
        
    }
}
