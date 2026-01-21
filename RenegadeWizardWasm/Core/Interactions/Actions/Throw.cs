using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Throw : GameAction
{
    public Throw()
    {
        Name = "Throw";
        Aka = ["Hurl", "Yeet", "Toss"];
        TargetHelpText = "I throw [name] at [name2]";
    }

    public override bool TryGetTargets(Interaction context)
    {
        try
        {
            context.ActualTargets.Add(context.DesiredTargets[0]);
            context.ActualTargets.Add(context.DesiredTargets[1]);
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

        var detach = new DetachEffect()
        {
            Actor = context.Actor,
            Target = context.ActualTargets[0],
            Context = context,
        };
        detach.Apply();

        if (detach.DetachOverflow < 1)
        {
            return;
        }
        
        var lift = new ThrowEffect()
        {
            Actor = context.Actor,
            Target = context.ActualTargets[0], 
            Context = context,
        };
        lift.Apply();

        if (lift.LiftOverflow > 0)
        {
            var damage = new DamageEffect
            {
                Actor = context.Actor,
                Target = context.ActualTargets[1], 
                Context = context,
                Damage = lift.LiftOverflow,
            };
            damage.Apply();
        }
        else
        {
            var damage = new DamageEffect
            {
                Result = $" {context.Actor.Name} drops the item on their foot!",
                Actor = context.Actor,
                Target = context.Actor, 
                Context = context,
                Damage = 1,
            };
            damage.Apply();
        }
    }
}
