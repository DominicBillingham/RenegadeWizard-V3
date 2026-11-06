using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions;

public class Fireball : BaseAction
{
    public override Identity Identity { get; set; } = new Identity
    {
        ActionId = ActionId.Fireball,
        Names = ["Fire", "Fireball"]
    };
}