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

    public Entity thrownee { get; set; }
    public Entity throwntoo { get; set; }

    public override void GetTargetsFromContext(ActionContext context)
    {
        thrownee = context.IntendedTargets[0];
        throwntoo = context.IntendedTargets[1];
    }
    
    public override void Perform(ActionContext context)
    {
        
        var forceMove = new ForceMoveEffect(context,
            context.Actor, 
            thrownee
        );

        if (forceMove.ActorCanMoveTarget == false)
        {
            return;
        }
        
        var collision = new CollisionEffect(
            context, 
            throwntoo,
            thrownee
        );

        if (throwntoo.Hitpoints > 0)
        {
            var damage = new DamageEffect(context, 
                context.Actor, 
                throwntoo, 
                thrownee.GetStat(Stat.Weight)
            );
        }
    }
}
