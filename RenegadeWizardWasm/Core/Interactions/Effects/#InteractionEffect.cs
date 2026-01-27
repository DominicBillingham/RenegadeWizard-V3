using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions;

public abstract class InteractionEffect
{
    public ActionContext Context { get; set; }
    public string Result { get; set; } = "";
    public bool HideResult { get; set; } = false;
    
    public InteractionEffect(ActionContext context)
    {
        context.CombatLog.Add(this);
        Context = context;
    }
    
}

public class ForceMoveEffect : InteractionEffect
{
    public bool ActorCanMoveTarget { get; set; } = false;
    public ForceMoveEffect(ActionContext context, Entity actor, Entity target) : base(context)
    {
        
        int actorStrength = actor.GetStat(Stat.Strength);
        int targetWeight = target.GetStat(Stat.Weight);

        if (target.Tags.FirstOrDefault(tag => tag is Attached) is Attached attached)
        {
            string attachedTo = attached.AttachedTo?.Name ?? "The structure";
            
            if (actorStrength > attached.AttachmentStrength)
            {
                Result += $"{actor.Name} rips {target.Name} from {attachedTo}.";
            }
            else
            {
                Result += $"{actor.Name} tries to pull apart {target.Name} and {attachedTo} - <fails>.";
                return;
            }
        }

        if (targetWeight > actorStrength)
        {
            Result += $"{actor.Name} tries to lift {target.Name} - <fails>.";
            return;
        }
        
        Result += $"{actor.Name} <powerfully> <throws> {target.Name}. ";
        ActorCanMoveTarget = true;
        
    }
}

public class CollisionEffect : InteractionEffect
{
    public CollisionEffect(ActionContext context, Entity target1, Entity target2) : base(context)
    {
        if (target1.Tags.FirstOrDefault(tag => tag is FallHazard) is FallHazard fallHazard)
        {
            Result += $"{target2.Name} falls off the map...";
            target2.Hitpoints = 0;
            return;
        }

        if (target2.Tags.FirstOrDefault(tag => tag is FallHazard) is FallHazard fallHazard2)
        {
            Result += $"{target1.Name} never stops falling...";
            target1.Hitpoints = 0;
            return;
        }
    }
}