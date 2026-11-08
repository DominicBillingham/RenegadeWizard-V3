using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DamageEffect : BaseEffect
{
    public int Damage { get; }
    public Entity Target { get; }

    public DamageEffect(int damage, Entity target)
    {
        Damage = damage;
        Target = target;
        target.Wounds += damage;
    }
}