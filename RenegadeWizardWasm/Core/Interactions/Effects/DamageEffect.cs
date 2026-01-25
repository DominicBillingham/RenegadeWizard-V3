namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class DamageEffect : InteractionEffect
{
    public DamageEffect(ActionContext context, int damage) : base(context)
    {
        var actor = context.Actor;
        var target = context.DesiredTargets.FirstOrDefault();
        
        if (target.Hitpoints < 1)
        {
            Result = $"but {target.Name} has already been destroyed!";
            return;
        }
        
        Result += $" {target.Name} takes {damage} damage.";
        target.Hitpoints -= damage;

        if (target.Hitpoints <= 0)
        {
            Result += $"{target.Name} <destroyed>";
        }
    }

}
