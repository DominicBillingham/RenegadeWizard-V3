namespace RenegadeWizardWasm.Core.Services;

public class DiceHelper
{
    public static int RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0)
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
    
    private static int RollDice(int sides)
    {
        return Random.Shared.Next(1, sides + 1);
    }
}