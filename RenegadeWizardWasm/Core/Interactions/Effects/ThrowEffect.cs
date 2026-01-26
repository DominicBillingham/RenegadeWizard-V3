using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class ThrowEffect : InteractionEffect
{
    public int LiftOverflow { get; set; } = 0;
    public ThrowEffect(ActionContext context, Entity actor, Entity target) : base(context)
    {
        int actorStrength = actor.GetStat(Stat.Strength);
        int targetWeight = target.GetStat(Stat.Weight);
        
        LiftOverflow = actorStrength - targetWeight;
        if (LiftOverflow > 0)
        {
            Result = $"{actor.Name} <powerfully> <throws> {target.Name}. ";
        }
        else
        {
            Result = $"{actor.Name} tries to lift {target.Name} - <fails>.";
        }
    }
    
}
