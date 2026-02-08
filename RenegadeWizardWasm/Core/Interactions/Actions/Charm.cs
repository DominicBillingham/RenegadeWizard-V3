using RenegadeWizardWasm.Core.Interactions.Effects;
using RenegadeWizardWasm.Core.Interactions.Entities;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Charm : GameAction
{
    public Charm()
    {
        Name = "Charm";
        Description = "Use your wits to change an enemy's allegiance to your own.";
        Aka = ["Flirt", "Inspire", "Convince", "Wink", "Hug", "Kiss"];
        TargetHelpText = "I charm [name]";
        ActionTags = ["Charm"];
    }
    
    public Entity target { get; set; }

    public override void GetTargetsFromContext(ActionContext context)
    {
        target = context.IntendedTargets[0];
    }
    
    public override void Perform(ActionContext context)
    {
        var charm = new CharmEffect(
            context,
            context.Actor, 
            target
        );
    }
}
