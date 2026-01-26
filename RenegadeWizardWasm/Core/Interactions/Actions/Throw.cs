using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Throw : GameAction
{
    public Throw()
    {
        Name = "Throw";
        Description = "Use your strength to throw an object at another object.";
        Aka = ["Hurl", "Yeet", "Toss"];
        TargetHelpText = "I throw [name] at [name2]";
    }

    public override bool TryGetTargets(ActionContext context)
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
    
    public override void Perform(ActionContext context)
    {

        var detach = new DetachEffect(context);

        if (detach.DetachOverflow < 1 && detach.AttachmentStrength > 0 )
        {
            return;
        }
        
        var lift = new ThrowEffect(context);

        if (lift.LiftOverflow > 0)
        {
            var damage = new DamageEffect(context, lift.LiftOverflow);
        }
        else
        {
            var damage = new DamageEffect(context, 1);
        }
    }
}
