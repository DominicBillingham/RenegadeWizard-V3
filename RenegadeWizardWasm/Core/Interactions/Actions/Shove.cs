using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions;

public class Shove : BaseAction
{
    public override ActionIdentity ActionIdentity { get; set; } = new ActionIdentity
    {
        ActionId = ActionId.Shove,
        Names = ["Kick", "Shove", "Push", "Shove"]
    };
    
    public void Execute(Entity attacker, Entity target)
    {
        var damage = new DamageEffect(1, target);
    }
}