using System;

public class Player
{
    public int RollDie()
    {
        var rand = new Random();
        int dieRoll = rand.Next(1, 19);

        return dieRoll;
    }

    public double GenerateSpellStrength()
    {
        var rand = new Random();
        double dieStregthSpell = rand.NextDouble() * 100;

        return dieStregthSpell;
    }
}
