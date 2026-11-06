using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions;

public class Fireball : BaseAction
{
    public override ActionIdentity ActionIdentity { get; set; } = new ActionIdentity
    {
        ActionId = ActionId.Fireball,
        Names = ["Fire", "Fireball"]
    };
    
    
}