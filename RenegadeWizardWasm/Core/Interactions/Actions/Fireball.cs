using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Fireball : BaseAction
{
    public override ActionIdentity ActionIdentity { get; set; } = new ActionIdentity
    {
        ActionId = ActionId.Fireball,
        Names = ["Fire", "Fireball"]
    };
    
    public override void Execute(IDiceRoller roller, List<Entity> targets)
    {
    }
}