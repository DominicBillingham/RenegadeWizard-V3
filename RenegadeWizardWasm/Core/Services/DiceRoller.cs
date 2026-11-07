namespace RenegadeWizardWasm.Core.Services;

public class DiceRoller : IDiceRoller
{
    public int RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        int highestDice = 1;
        
        foreach (int roll in Enumerable.Range(1, diceCount))
        {
            int diceRoll = RollDice(diceSize);
            if (diceRoll > highestDice)
            {
                highestDice = diceRoll;
            }
            if (diceRoll < rerollThreshold)
            {
                diceRoll = RollDice(diceSize);
            }
        }
        return highestDice;
    }
    
    private int RollDice(int sides)
    {
        return Random.Shared.Next(1, sides + 1);
    }
}

// Below are the rigged dice rollers for testing purposes.
// Or if I feel like rigging the game against the player!

public class DiceRollerCrit : IDiceRoller
{
    public int RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        return 9;
    }
}

public class DiceRollerPass : IDiceRoller
{
    public int RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        return 6;
    }
}

public class DiceRollerFail : IDiceRoller
{
    public int RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        return 5;
    }
}
