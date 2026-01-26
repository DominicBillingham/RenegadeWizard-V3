using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Punch : GameAction
{
    public Punch()
    {
        Name = "Punch";
        Description = "Use your fists to strike an enemy. A tad boring though...";
        Aka = ["Hit", "Slap", "Whack"];
        TargetHelpText = "Punch [name]";
        ActionTags = ["Contact", "Damage"];
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
    
    public override void Perform(ActionContext context)
    {
        var damage = new DamageEffect(
            context, 
            context.Actor, 
            context.DesiredTargets[0], 
            1
        );
    }
}
