namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DamageEffect : InteractionEffect
{
    public int Damage { get; set; }
    protected override void Core()
    {
        if (Target.Hitpoints < 1)
        {
            Result = $"but {Target.Name} has already been destroyed!";
            return;
        }
        
        Result += $" {Target.Name} takes {Damage} damage.";
        Target.Hitpoints -= Damage;

        if (Target.Hitpoints <= 0)
        {
            Result += $"{Target.Name} <destroyed>";
        }
        
        
    }
}
