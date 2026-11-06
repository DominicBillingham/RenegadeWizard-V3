using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions;

public abstract class BaseAction
{
    public abstract ActionIdentity ActionIdentity { get; set; }
    public abstract void Execute(List<Entity> targets);
}