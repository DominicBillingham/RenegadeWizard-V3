using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class ConsumeEffect : BaseEffect
{
    public required Entity Consumer { get; set; }
    public required Entity Target { get; set; }
    
    public override void Execute()
    {
        if ((int)Consumer.Size > (int)Target.Size)
        {
            Target.IsDefeated = true;
            if (Target.Tags.Contains(Tags.Edible))
            {
                Consumer.Wounds -= 1;
            }
            else if (Target.Tags.Contains(Tags.InedibleAndHurtful))
            {
                Consumer.Wounds += 1;
            }
        }
        else
        {
            new DamageEffect()
            {
                Context = Context,
                Damage = 1,
                Target = Target
            }.Execute();
        }
    }
}