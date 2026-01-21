using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Consume : GameAction
{
    public Consume()
    {
        Name = "Consume";
        Description = "Attempt to devour literally anything - regardless of if it's a good idea or not.";
        Aka = ["Eat", "Drink", "Devour", "Ingest", "Swallow", "Digest"];
        TargetHelpText = "I consume [name]";
    }

    public override bool TryGetTargets(Interaction context)
    {
        try
        {
            context.ActualTargets.Add(context.DesiredTargets[0]);
            return true;
        }
        catch
        {
            context.Result = $"{context.Actor.Name} fails to find targets for {context.GameAction.Name}.";
            return false;
        }
    }
    
    public override void StackEffects(Interaction context)
    {
        var touch = new ContactEffect()
        {
            Actor = context.Actor,
            Target = context.ActualTargets[0],
            Context = context,
        };
        touch.Apply();
        
        var eat = new ConsumeEffect()
        {
            Actor = context.Actor,
            Target = context.ActualTargets[0], 
            Context = context,
        };
        eat.Apply();
    }
}
