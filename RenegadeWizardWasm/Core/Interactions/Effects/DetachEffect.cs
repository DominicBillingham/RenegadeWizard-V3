using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DetachEffect : InteractionEffect
{
    public int AttachmentStrength { get; set; } = 0;
    public int DetachOverflow { get; set; } = 0;
    
    public DetachEffect(ActionContext context) : base(context)
    {
        if (AttachmentStrength == 0)
            return;
        
        var actor = context.Actor;
        var target = context.DesiredTargets.FirstOrDefault();
        
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
