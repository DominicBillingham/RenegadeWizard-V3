using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DamageEffect : BaseEffect
{
    public required int Damage { get; set; }
    public required Entity Target { get; set; }

    public override void Execute()
    {
        Target.Wounds += Damage;
    }
    
}