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
    
    public void Execute(Entity attacker, Entity target)
    {
        var damage = new DamageEffect(1, target);
    }
}