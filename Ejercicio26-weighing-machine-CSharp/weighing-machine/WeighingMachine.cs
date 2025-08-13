class WeighingMachine
{
    //Constructor
    public WeighingMachine(int precision)
    {
        _precision = precision;
    }

    // TODO: define the 'Precision' property
    private int _precision;
    public int Precision{
        get {return  _precision;}
    }

    // TODO: define the 'Weight' property
    private double _weight;
    public double Weight 
    {
        get{return _weight;}
        set
        {
            if(value < 0)
            {
                throw new ArgumentOutOfRangeException("Negative weight not valid");
            }else{
                _weight = value;
            }
        }
    }

    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get
        {
            double netWeight = _weight - TareAdjustment;
            return $"{netWeight.ToString($"F{Precision}")} kg";
            
        }
    }


    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment {get; set;} = 5.0;
}
