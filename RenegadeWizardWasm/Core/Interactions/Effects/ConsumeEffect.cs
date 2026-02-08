using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class ConsumeEffect : InteractionEffect
{
    public ConsumeEffect(ActionContext context, Entity actor, Entity target) : base(context)
    {
        int actorSize = actor.GetStat(Stat.Size);
        int targetFoodValue = target.GetStat(Stat.FoodValue);
        int targetTaste = target.GetStat(Stat.Taste);
        int targetSize = target.GetStat(Stat.Size);
        
        if (actor == target)
        {
            Result = $"{actor.Name} tries to eat themselves. <wtf>";
            return;
        }
        
        if (actorSize > targetSize)
        {
            
            target.Hitpoints = 0;
            actor.Hitpoints += targetFoodValue;
            Result = $"{actor.Name} <powerfully> consumes {target.Name}.";

            if (targetFoodValue > 0)
            {
                Result += $"{actor.Name} heals {targetFoodValue}hp.";
            }

            if (targetTaste < 2)
            {
                Result += $"<wtf>";
            } 
            else if (targetTaste < 5)
            {
                Result += $"<gross>";
            }

            if (target.Tags.FirstOrDefault(tag => tag is Explosive) is Explosive explosive)
            {
                Result += $"{actor.Name} is now explosive! <wtf>";
                actor.Tags.Add(new Explosive(Duration.Permanent));
            }
            
        }
        else
        {
            Result = $"{target.Name} is too big to eat. <obvious>";
        }
        
    }
}
