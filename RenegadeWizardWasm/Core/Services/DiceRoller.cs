using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Services;

public class DiceRoller : IDiceRoller
{
    public DiceOutcome RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        int highestDice = 1;
        
        for (int i = 0; i < diceCount; i++)
        {
            int diceRoll = RollDice(diceSize);
            
            if (diceRoll < rerollThreshold)
            {
                diceRoll = RollDice(diceSize);
            }
            if (diceRoll > highestDice)
            {
                highestDice = diceRoll;
            }
        }

        if (highestDice >= (int)DiceOutcome.Crit)
        {
            return DiceOutcome.Crit;
        }
        if (highestDice >= (int)DiceOutcome.Pass)
        {
            return DiceOutcome.Pass;
        }
        return DiceOutcome.Fail;
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
    public DiceOutcome RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        return DiceOutcome.Crit;
    }
}

public class DiceRollerPass : IDiceRoller
{
    public DiceOutcome RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        return DiceOutcome.Pass;
    }
}

public class DiceRollerFail : IDiceRoller
{
    public DiceOutcome RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        return DiceOutcome.Fail;
    }
}
