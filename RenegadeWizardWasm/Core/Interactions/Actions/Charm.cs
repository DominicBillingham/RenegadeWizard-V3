using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Charm : GameAction
{
    public Charm()
    {
        Name = "Charm";
        Description = "Use your wits to change an enemy's allegiance to your own.";
        Aka = ["Flirt", "Inspire", "Convince", "Wink", "Hug", "Kiss"];
        TargetHelpText = "I charm [name]";
    }

    public override bool TryGetTargets(ActionContext context)
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
    
    public override void StackEffects(ActionContext context)
    {
        var charm = new CharmEffect()
        {
            Actor = context.Actor,
            Target = context.ActualTargets[0], 
            Context = context,
        };
        charm.Apply();
    }
}
