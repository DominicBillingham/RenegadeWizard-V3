namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class ConsumeEffect : InteractionEffect
{
    protected override void Core()
    {
        if (Actor == Target)
        {
            Result = $"{Actor.Name} tries to eat themselves. <wtf>";
            return;
        }
        
        if (Actor.Size > Target.Size)
        {
            Target.Hitpoints = 0;
            Actor.Hitpoints += Target.FoodValue;
            Result = $"{Actor.Name} <powerfully> consumes {Target.Name}.";

            if (Target.FoodValue > 0)
            {
                Result += $" {Actor.Name} heals {Target.FoodValue}hp.";
            }

            if (Target.Taste < 2)
            {
                Result += $" <wtf>";
            } 
            else if (Target.Taste < 5)
            {
                Result += $" <gross>";
            }
            
        }
        else
        {
            Result = $"{Target.Name} is too big to eat. <obvious>";
        }
        
    }
}
