using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Attack : BaseAction
{
    
    public override ActionIdentity ActionIdentity { get; set; } = new ActionIdentity
    {
        ActionId = ActionId.Attack,
        Names = ["Punch", "Attack", "Murder", "Knockout", "Kill"]
    };
    
    public override void Execute(IDiceRoller roller, List<Entity> targets)
    {

        DiceOutcome roll = roller.RollDicePool(10, 1);
        
        var damage = new DamageEffect(1, targets[0]);
        
        
    }
}