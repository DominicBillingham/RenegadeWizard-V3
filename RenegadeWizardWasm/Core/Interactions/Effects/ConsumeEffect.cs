using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class ConsumeEffect : InteractionEffect
{
    protected override void Core()
    {
        int actorSize = Actor.GetStat(Stat.Size);
        int targetFoodValue = Target.GetStat(Stat.FoodValue);
        int targetTaste = Target.GetStat(Stat.Taste);
        int targetSize = Target.GetStat(Stat.Size);
        
        if (Actor == Target)
        {
            Result = $"{Actor.Name} tries to eat themselves. <wtf>";
            return;
        }
        
        if (actorSize >targetSize)
        {
            
            Target.Hitpoints = 0;
            Actor.Hitpoints += targetFoodValue;
            Result = $"{Actor.Name} <powerfully> consumes {Target.Name}.";

            if (targetFoodValue > 0)
            {
                Result += $" {Actor.Name} heals {targetFoodValue}hp.";
            }

            if (targetTaste < 2)
            {
                Result += $" <wtf>";
            } 
            else if (targetTaste < 5)
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
