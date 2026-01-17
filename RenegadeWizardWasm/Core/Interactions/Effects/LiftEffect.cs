namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class LiftEffect : InteractionEffect
{
    public int LiftOverflow { get; set; }
    protected override void Core()
    {
        LiftOverflow = Actor.Strength - Target.Weight;
        if (LiftOverflow > 0)
        {
            Result = $"{Actor.Name} <powerfully> lifts {Target.Name} ";
        }
        else
        {
            Result = $"{Actor.Name} tries to lift {Target.Name} <fails>.";
        }
    }
}
