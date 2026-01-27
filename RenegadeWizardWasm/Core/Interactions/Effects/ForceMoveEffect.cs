using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

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
