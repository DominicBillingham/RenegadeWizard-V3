using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Entities;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DetachEffect : InteractionEffect
{
    public int AttachmentStrength { get; set; } = 0;
    public int DetachOverflow { get; set; } = 0;
    
    public DetachEffect(ActionContext context, Entity actor, Entity target) : base(context)
    {
        if (AttachmentStrength == 0)
            return;
        
        int actorStrength = actor.GetStat(Stat.Strength);
        
        DetachOverflow = actorStrength - AttachmentStrength;
        
        if (DetachOverflow > 0)
        {
            Result = $"{actor.Name} <powerfully> rips {target.Name} away. ";
        }
        else
        {
            Result = $"{actor.Name} tries to detach {target.Name} - <fails>.";
        }
    }

}
