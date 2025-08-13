public class WeatherStation
{
    private Reading reading;
    private List<DateTime> recordDates = new List<DateTime>();
    private List<decimal> temperatures = new List<decimal>();

    public void AcceptReading(Reading reading)
    {
        this.reading = reading;
        recordDates.Add(DateTime.Now);
        temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        reading = new Reading();
        recordDates.Clear();
        temperatures.Clear();
    }

    public decimal LatestTemperature
    {
        get => reading.Temperature;
        
    }

    public decimal LatestPressure
    {
        get => reading.Pressure;
        
    }

    public decimal LatestRainfall
    {
        get => reading.Rainfall;
        
    }

    public bool HasHistory
    {
        get => recordDates.Count > 1;
        
    }

    public Outlook ShortTermOutlook
    {
        get
        {
            //Fijo que se puede modificar. un switch con expresiones(?)
            if (reading.Equals(new Reading()))
            {
                throw new ArgumentException();
            }
            
            return (reading.Pressure, reading.Temperature) switch
            {
                (< 10m, < 30m) => Outlook.Cool, // Caso donde Pressure < 10 y Temperature < 30
                (_ , > 50m) => Outlook.Good,    // Caso donde Temperature > 50 , _ aqui indica que el valor de reading.Temperature es irrelevante
                _ => Outlook.Warm              // Por defecto
            };
        }
    }

    public Outlook LongTermOutlook
    {
        get
        {
            return reading.WindDirection switch
            {
                WindDirection.Southerly => Outlook.Good,
                WindDirection.Easterly when reading.Temperature > 20 => Outlook.Good,
                WindDirection.Northerly => Outlook.Cool,
                WindDirection.Easterly when reading.Temperature <= 20 => Outlook.Warm,
                WindDirection.Westerly => Outlook.Rainy,
                _ => throw new ArgumentException()  // Si no se cumple ninguna condición
            };
        }
    }

    public State RunSelfTest()
    {
        return reading.Equals(new Reading()) ? State.Bad : State.Good;
        
    }
}

/*** Please do not modify this struct ***/
public struct Reading
{
    public decimal Temperature { get; }
    public decimal Pressure { get; }
    public decimal Rainfall { get; }
    public WindDirection WindDirection { get; }

    public Reading(decimal temperature, decimal pressure,
        decimal rainfall, WindDirection windDirection)
    {
        Temperature = temperature;
        Pressure = pressure;
        Rainfall = rainfall;
        WindDirection = windDirection;
    }
}

/*** Please do not modify this enum ***/
public enum State
{
    Good,
    Bad
}

/*** Please do not modify this enum ***/
public enum Outlook
{
    Cool,
    Rainy,
    Warm,
    Good
}

/*** Please do not modify this enum ***/
public enum WindDirection
{
    Unknown, // default
    Northerly,
    Easterly,
    Southerly,
    Westerly
}
