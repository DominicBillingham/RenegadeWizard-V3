namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DamageEffect : InteractionEffect
{
    public int Damage { get; set; }

    public DamageEffect(ActionContext context) : base(context)
    {
        var actor = context.Actor;
        var target = context.DesiredTargets.FirstOrDefault();
        
        if (target.Hitpoints < 1)
        {
            Result = $"but {target.Name} has already been destroyed!";
            return;
        }
        
        Result += $" {target.Name} takes {Damage} damage.";
        target.Hitpoints -= Damage;

        if (target.Hitpoints <= 0)
        {
            Result += $"{target.Name} <destroyed>";
        }
    }

}
