abstract class Character
{
    protected string _characterType;
    protected bool _vulnerable = false;

    protected Character(string characterType)
    {
        _characterType = characterType;        
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return _vulnerable;
    }

    public override string ToString()
    {
        return "Character is a " + _characterType;      
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if(target.Vulnerable())
        {
            return 10;
        }else
        {
            return 6;
        }
    }
}

class Wizard : Character
{
    private bool _preparedSpell = false;
    public Wizard() : base("Wizard")
    {
        base._vulnerable = true;
    }

    public override int DamagePoints(Character target)
    {
        if(_preparedSpell)
        {
            return 12;
        }else
        {
            return 3;
        }
    }

    public void PrepareSpell()
    {
        _preparedSpell = true;  
        base._vulnerable = false;    
    }
}
