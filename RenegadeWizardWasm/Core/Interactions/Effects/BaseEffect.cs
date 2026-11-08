using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public abstract class BaseEffect
{
    public required ActionContext Context { get; set; }
    public abstract void Execute();
}