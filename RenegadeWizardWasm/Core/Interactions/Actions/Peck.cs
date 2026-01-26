using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Peck : GameAction
{
    public Peck()
    {
        Name = "Peck";
        Description = "A rather painful bite attack from a beaked creature.";
        TargetHelpText = "Peck [name]";
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
