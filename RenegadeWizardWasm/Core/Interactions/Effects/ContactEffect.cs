using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class ContactEffect : BaseEffect
{
    public required Entity Target1 { get; init; }
    public required Entity Target2 { get; init; }

    public override void Execute()
    {
        if (Target1.Tags.Contains(Tags.Spiky))
        {
            var effect = new DamageEffect
            {
                Context = Context,
                Target = Target2,
                Damage = 1,
            };
            effect.Execute();
        }
        else if (Target2.Tags.Contains(Tags.Spiky))
        {
            var effect = new DamageEffect
            {
                Context = Context,
                Target = Target1,
                Damage = 1,
            };
            effect.Execute();
        }
    }

}