using System.Diagnostics.CodeAnalysis;
using RenegadeWizardWasm.Core.Interactions.Entities;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DamageEffect : InteractionEffect
{
    public DamageEffect(ActionContext context, Entity actor, Entity target, int damage) : base(context)
    {
        if (target.Hitpoints < 1)
        {
            Result += $"but {target.Name} has already been destroyed!";
            return;
        }

        if (target.Tags.FirstOrDefault(tag => tag is Vulnerable) is Vulnerable vulnerable)
        {
            damage *= 2;
        }
        
        if (target.Tags.FirstOrDefault(tag => tag is Deflecting) is Deflecting deflecting)
        {
            Result += $"but {target.Name} is deflecting the damage.";
        }
        else if (target.Tags.FirstOrDefault(tag => tag is Immortal) is Immortal immortal)
        {
            Result += $"but {target.Name} is completely immortal.";
        }
        else
        {
            Result += $"{target.Name} takes {damage} damage.";
            target.Hitpoints -= damage;
        }
        
        if (target.Tags.FirstOrDefault(tag => tag is Tenacious) is Tenacious tenacious)
        {
            if (target.Hitpoints <= 0 && target.Hitpoints != 1)
            {
                target.Hitpoints = 1;
                Result += $"{target.Name} takes {damage} damage, but clings onto life!";
            }
        }
        
        if (target.Hitpoints <= 0)
        {
            if (target.Tags.FirstOrDefault(tag => tag is Explosive) is Explosive explosive)
            {
                Result += $"{target.Name} explodes!";
            }
            
        }
    }

}
