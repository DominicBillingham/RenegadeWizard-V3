using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class CollisionEffect : InteractionEffect
{
    public CollisionEffect(ActionContext context, Entity target1, Entity target2) : base(context)
    {
        if (target1.Tags.FirstOrDefault(tag => tag is FallHazard) is FallHazard fallHazard)
        {
            Result += $"{target2.Name} falls off the map...";
            target2.Hitpoints = 0;
            return;
        }

        if (target2.Tags.FirstOrDefault(tag => tag is FallHazard) is FallHazard fallHazard2)
        {
            Result += $"{target1.Name} never stops falling...";
            target1.Hitpoints = 0;
            return;
        }
    }
}
