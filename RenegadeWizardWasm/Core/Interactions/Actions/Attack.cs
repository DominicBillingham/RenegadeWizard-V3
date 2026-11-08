using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;
using RenegadeWizardWasm.Core.Models;

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
        Entity? target = context.IntendedTargets.FirstOrDefault();
        
        context.Roller.RollDicePool(10, 1);

        if (target == null) return;
        
        new ContactEffect
        {
            Context = context,
            Target1 = context.Executor,
            Target2 = target
        }.Execute();

        if (context.Roller.Outcome == DiceOutcome.Crit)
        {   
            var effect = new DamageEffect
            {
                Context = context,
                Target = target,
                Damage = 1,
            };
            effect.Execute();
        }
        else if (context.Roller.Outcome == DiceOutcome.Pass)
        {
            target.Tags.Add(Tags.Stunned);
        }
        else if (context.Roller.Outcome == DiceOutcome.Fail)
        {
            context.Executor.Stress += 1;
        }
    }
}