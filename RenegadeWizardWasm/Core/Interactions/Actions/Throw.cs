using RenegadeWizardWasm.Core.Enums;
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
        ActionTags = ["Contact", "Push", "Damage"];
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
        
        var forceMove = new ForceMoveEffect(context,
            context.Actor, 
            context.DesiredTargets[0]
        );

        if (forceMove.ActorCanMoveTarget == false)
        {
            return;
        }
        
        var collision = new CollisionEffect(
            context, 
            context.DesiredTargets[0], 
            context.DesiredTargets[1]
        );

        if (context.DesiredTargets[0].Hitpoints > 0)
        {
            var damage = new DamageEffect(context, 
                context.Actor, 
                context.DesiredTargets[1] , 
                context.DesiredTargets[0].GetStat(Stat.Weight)
            );
        }
    }
}
