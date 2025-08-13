
public class Player
{
    private Random random = new Random();

    public int RollDie()
    {
        return random.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        double randomDouble = random.NextDouble() * 100;
        return randomDouble;
    }
}
