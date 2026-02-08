using RenegadeWizardWasm.Core.Interactions.Entities;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class HealEffect : InteractionEffect
{
    public int AmountHealed { get; set; } = 0;

    public HealEffect(ActionContext context, Entity actor, Entity target, int amount) : base(context)
    {
        if (target.Hitpoints < 1)
        {
            Result += $"but {target.Name} is already dead!";
            return;
        }

        Result += $"{target.Name} heals {amount} hitpoints.";
        target.Hitpoints += amount;
        AmountHealed = amount;
    }
}
