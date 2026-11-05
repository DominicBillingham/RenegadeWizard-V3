using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions;

public abstract class BaseAction
{
    public abstract Identity Identity { get; set; }
}