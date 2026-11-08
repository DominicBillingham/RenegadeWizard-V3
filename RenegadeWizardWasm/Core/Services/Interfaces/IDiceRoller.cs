using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Services;

public abstract class IDiceRoller
{
    public DiceOutcome Outcome { get; protected set; }
    public List<int> Rolls { get; private set; } = new();
    public abstract void RollDicePool(int diceSize, int diceCount, int rerollThreshold = 0);
}
