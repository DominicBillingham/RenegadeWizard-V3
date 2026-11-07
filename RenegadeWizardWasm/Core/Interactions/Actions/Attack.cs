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
    
    public override void Execute(ActionContext context)
    {
        DiceOutcome roll = context.Roller.RollDicePool(10, 1);
        Entity? target = context.IntendedTargets.FirstOrDefault();

        if (target == null) return;

        if (roll == DiceOutcome.Crit)
        {
            new DamageEffect(1, target);
        }
        else if (roll == DiceOutcome.Pass)
        {
            target.Tags.Add(Tags.Stunned);
        }
        else if (roll == DiceOutcome.Fail)
        {
            context.Executor.Stress += 1;
        }
    }
}