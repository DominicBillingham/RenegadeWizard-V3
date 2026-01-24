using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardWasm.Core.Interactions;


public abstract class Modifier
{
    public string Name { get; set; } = "";
    public Duration Duration { get; set; } = Duration.Permanent;
    public virtual void ModifyEffects(InteractionEffect effect) {}
    public virtual void ModifyStats(Stat stat, ref int statValue) {}

    public virtual void EndOfRound()
    {
        
    }

}


public class Vulnerable : Modifier
{
    public Vulnerable()
    {
        Name = "Death Marked";
        Duration = Duration.SingleCombat;
    }

    public override void ModifyEffects(InteractionEffect effect)
    {
        if (effect is DamageEffect damageEffect)
        {
            damageEffect.Damage *= 2;
        }
    }
}


public class Enlarged : Modifier
{
    public Enlarged()
    {
        Name = "Enlarged";
        Duration = Duration.SingleCombat;
    }
    
    public override void ModifyStats(Stat stat, ref int statValue)
    {
        if (stat == Stat.Size)
        {
            statValue = statValue * 2;
        }

        if (stat == Stat.Weight)
        {
            statValue = statValue * 2;
        }

        if (stat == Stat.Strength)
        {
            statValue = statValue * 2;
        }
    }
    
}


public class Relentless : Modifier
{
    public Relentless()
    {
        Name = "Relentless";
    }
    
    public override void ModifyEffects(InteractionEffect effect)
    {
        if (effect is DamageEffect damageEffect)
        {
            int healthPredication = damageEffect.Actor.Hitpoints - damageEffect.Damage;

            if (healthPredication < 1)
            {
                
            }
        }
        
    } 
}
