using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions;

public class Attack : BaseAction
{
    
    public override ActionIdentity ActionIdentity { get; set; } = new ActionIdentity
    {
        ActionId = ActionId.Attack,
        Names = ["Punch", "Attack", "Murder", "Knockout", "Kill"]
    };
    
    public override void Execute(List<Entity> targets)
    {
        var damage = new DamageEffect(1, targets[0]);
    }
}