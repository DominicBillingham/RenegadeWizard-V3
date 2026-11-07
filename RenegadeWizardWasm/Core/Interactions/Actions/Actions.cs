using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public abstract class BaseAction
{
    public abstract ActionIdentity ActionIdentity { get; set; }
    public abstract void Execute(IDiceRoller diceRoller, List<Entity> targets);
}