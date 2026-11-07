using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Services;

public interface IDiceRoller
{
    DiceOutcome RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0);
}
