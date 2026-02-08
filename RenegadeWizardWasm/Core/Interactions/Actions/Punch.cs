using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;
using RenegadeWizardWasm.Core.Interactions.Entities;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Punch : GameAction
{
    public Punch()
    {
        Name = "Punch";
        Description = "Use your fists to strike an enemy. A tad boring though...";
        Aka = ["Hit", "Slap", "Whack"];
        Intent = Intent.Attack;
        TargetHelpText = "Punch [name]";
        ActionTags = ["Contact", "Damage"];
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
