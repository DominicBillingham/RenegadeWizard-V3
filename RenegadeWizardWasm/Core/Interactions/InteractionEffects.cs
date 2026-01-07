namespace RenegadeWizardWasm.Core;

    public abstract class InteractionEffects()
{
    public List<Entity> Targets { get; set; } = [];
    public Entity Actor { get; set; }
    public List<Modifier> Modifiers { get; set; } = [];
    public string Text { get; set; } = "";
    public abstract void Apply();
}

public class DamageEffects() : InteractionEffects()
{
    public int Damage { get; set; }

    public override void Apply()
    {
        
        var firstTarget = Targets.FirstOrDefault();
        if (firstTarget == null)
        {
            Text += "No targets found.";
            return;
        }
        
        Modifiers = firstTarget.Modifiers;
        
        foreach (var mod in Modifiers)
        {
            mod.ModifyEffect(this);
        }
        
        Text += $"{firstTarget.Name} takes {Damage} damage";

        if (Modifiers.Any())
        {
            Text += $", modifed by [{string.Join(", ", Modifiers.Select(mod => mod.Name))}].";
        }

        firstTarget.Hitpoints -= Damage;
    }
}

// public class ThrowEffect() : InteractionEffects()
// {
//     
//     public int Damage { get; set; }
//
//     public override void Apply(Entity target)
//     {
//         foreach (var mod in Modifiers)
//         {
//             mod.ModifyEffect(this);
//         }
//
//         Text += $"{target.Name} takes {Damage} damage";
//
//         if (Modifiers.Any())
//         {
//             Text += $", modifed by [{string.Join(", ", Modifiers.Select(mod => mod.Name))}].";
//         }
//
//         target.Hitpoints -= Damage;
//     }
// }