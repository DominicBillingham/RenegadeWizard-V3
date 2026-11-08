using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Services;

public class DiceRoller : IDiceRoller
{
    
    public override void RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        int highestDice = 1;
        
        for (int i = 0; i < diceCount; i++)
        {
            int diceRoll = RollDice(diceSize);
            
            Rolls.Add(diceRoll);
            
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
            Outcome = DiceOutcome.Crit;
        }
        if (highestDice >= (int)DiceOutcome.Pass)
        {
            Outcome = DiceOutcome.Pass;
        }
        else
        {
            Outcome = DiceOutcome.Fail;
        }
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
    public override void RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        Outcome = DiceOutcome.Crit;
    }
}

public class DiceRollerPass : IDiceRoller
{
    public override void RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        Outcome = DiceOutcome.Pass;
    }
}

public class DiceRollerFail : IDiceRoller
{
    public override void RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
    {
        Outcome = DiceOutcome.Fail;
    }
}
