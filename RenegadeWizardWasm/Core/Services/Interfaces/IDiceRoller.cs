namespace RenegadeWizardWasm.Core.Services;

public interface IDiceRoller
{
    int RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0);
}
