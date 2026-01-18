using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class ThrowEffect : InteractionEffect
{
    public int LiftOverflow { get; set; }
    protected override void Core()
    {
        int actorStrength = Actor.GetStat(Stat.Strength);
        int targetWeight = Target.GetStat(Stat.Weight);
        
        LiftOverflow = actorStrength - targetWeight;
        if (LiftOverflow > 0)
        {
            Result = $"{Actor.Name} <powerfully> <throws> {Target.Name}. ";
        }
        else
        {
            Result = $"{Actor.Name} tries to lift {Target.Name} - <fails>.";
        }
    }
}
