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
    
    public override void StackEffects(ActionContext context)
    {
        var damage = new DamageEffect
        {
            Actor = context.Actor,
            Target = context.ActualTargets.First(),
            Context = context,
            Damage = 2,
        };
        damage.Apply();
    }
}
