using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Peck : GameAction
{
    public Peck()
    {
        Name = "Peck";
        Description = "A rather painful bite attack from a beaked creature.";
        Intent = Intent.Attack;
        TargetHelpText = "Peck [name]";
    }

    public Entity target { get; set; }

    public override void GetTargetsFromContext(ActionContext context)
    {
        target = context.IntendedTargets[0];
    }
    
    public override void Perform(ActionContext context)
    {
        var damage = new DamageEffect(
            context, 
            context.Actor, 
            target,
            1
        );
    }
}
