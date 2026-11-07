using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Shove : BaseAction
{
    public override ActionIdentity ActionIdentity { get; set; } = new ActionIdentity
    {
        ActionId = ActionId.Shove,
        Names = ["Kick", "Shove", "Push", "Shove"]
    };
    
    public override void Execute(ActionContext context)
    {
    }
}