namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DamageEffect : InteractionEffect
{
    public int Damage { get; set; }
    protected override void Core()
    {
        Result += $" {Target.Name} takes {Damage} damage.";
        Target.Hitpoints -= Damage;

        if (Target.Hitpoints < 0)
        {
            Result += $"{Target.Name} <destroyed>";
        }
        
        
    }
}
