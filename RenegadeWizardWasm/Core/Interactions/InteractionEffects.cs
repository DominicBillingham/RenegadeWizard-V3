namespace RenegadeWizardWasm.Core;

public abstract class InteractionEffects()
{
    public Entity Target { get; set; }
    public Entity Actor { get; set; }
    public List<Modifier> Modifiers { get; set; } = [];
    public string Text { get; set; } = "";
    public abstract void Apply(Entity target);
}

public class DamageEffects() : InteractionEffects()
{
    public int Damage { get; set; }

    public override void Apply(Entity target)
    {
        foreach (var mod in Modifiers)
        {
            mod.ModifyEffect(this);
        }

        Text += $"{target.Name} takes {Damage} damage";

        if (Modifiers.Any())
        {
            Text += $", modifed by [{string.Join(", ", Modifiers.Select(mod => mod.Name))}].";
        }

        target.Hitpoints -= Damage;
    }
}

public class ThrowEffect() : InteractionEffects()
{
    public int Damage { get; set; }

    public override void Apply(Entity target)
    {
        foreach (var mod in Modifiers)
        {
            mod.ModifyEffect(this);
        }

        Text += $"{target.Name} takes {Damage} damage";

        if (Modifiers.Any())
        {
            Text += $", modifed by [{string.Join(", ", Modifiers.Select(mod => mod.Name))}].";
        }

        target.Hitpoints -= Damage;
    }
}