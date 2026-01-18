namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class ThrowEffect : InteractionEffect
{
    public int LiftOverflow { get; set; }
    protected override void Core()
    {
        LiftOverflow = Actor.Strength - Target.Weight;
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
