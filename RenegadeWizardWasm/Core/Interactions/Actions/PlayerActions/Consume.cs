using RenegadeWizardWasm.Core.Interactions.Effects;
using RenegadeWizardWasm.Core.Interactions.Entities;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Consume : GameAction
{
    public Consume()
    {
        Name = "Consume";
        Description = "Attempt to devour literally anything - regardless of if it's a good idea or not.";
        Aka = ["Eat", "Drink", "Devour", "Ingest", "Swallow", "Digest"];
        TargetHelpText = "I consume [name]";
        ActionTags = ["Contact", "Damage", "Healing"];
    }

    public Entity target { get; set; }

    public override void GetTargetsFromContext(ActionContext context)
    {
        target = context.IntendedTargets[0];
    }
    
    public override void Perform(ActionContext context)
    {
        var touch = new ContactEffect(context, context.Actor, target);
        var eat = new ConsumeEffect(context, context.Actor, target);
    }
}
