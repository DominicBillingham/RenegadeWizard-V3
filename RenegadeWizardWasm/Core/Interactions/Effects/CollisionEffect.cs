using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class CollisionEffect : InteractionEffect
{
    public bool PerformFollowupDamage { get; set; } = true;
    
    public CollisionEffect(ActionContext context, Entity target1, Entity target2) : base(context)
    {
        if (target2.Tags.FirstOrDefault(tag => tag is FallHazard) is FallHazard fallHazard2)
        {
            Result += $"{target1.Name} falls out the tower...";
            target1.Hitpoints = 0;
            PerformFollowupDamage = false;
            return;
        }
        
        if (target1.Tags.FirstOrDefault(tag => tag is FallHazard) is FallHazard fallHazard)
        {
            Result += $"{target2.Name} falls out the tower...";
            target2.Hitpoints = 0;
            PerformFollowupDamage = false;
            return;
        }
        
    }
}
