using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;
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

        Entity target = GetEntity(context, 0);
        Entity? destination = GetOptionalEntity(context, 1);

        new ContactEffect
        {
            Context = context,
            Target1 = context.Executor,
            Target2 = target
        }.Execute();

        int diceToRoll = 1;
        
        if ((int)context.Executor.Size > (int)target.Size)
        {
            diceToRoll++;
        }
        else if ((int)context.Executor.Size < (int)target.Size)
        {
            diceToRoll--;
        }
        else
        {
            diceToRoll = 1;
        }
        
        context.Roller.RollDicePool(10, diceToRoll);
        
        
        
    }
}