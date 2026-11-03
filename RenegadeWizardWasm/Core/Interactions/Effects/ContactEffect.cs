using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class ContactEffect
{
    public ContactEffect(Entity target1, Entity target2)
    {
        if (target1.Tags.Contains(Tags.Spiky))
        {
            new DamageEffect(1, target2);
        }
        else if (target2.Tags.Contains(Tags.Spiky))
        {
            new DamageEffect(1, target1);
        }
    }
}