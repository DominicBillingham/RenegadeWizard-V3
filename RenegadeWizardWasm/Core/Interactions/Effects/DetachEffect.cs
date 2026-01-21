using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DetachEffect : InteractionEffect
{
    public int AttachmentStrength { get; set; } = 0;
    public int DetachOverflow { get; set; } = 0;
    
    protected override void Core()
    {
        if (AttachmentStrength == 0)
            return;
        
        int actorStrength = Actor.GetStat(Stat.Strength);
        
        DetachOverflow = actorStrength - AttachmentStrength;
        
        if (DetachOverflow > 0)
        {
            Result = $"{Actor.Name} <powerfully> rips {Target.Name} away. ";
        }
        else
        {
            Result = $"{Actor.Name} tries to detach {Target.Name} - <fails>.";
        }
    }
}
