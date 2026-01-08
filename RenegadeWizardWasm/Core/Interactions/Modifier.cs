namespace RenegadeWizardWasm.Core;

public enum ModType
{
    DamageReduction,
}

public abstract class Modifier
{
    public string Name { get; set; } = "";
    
    public ModType Type { get; set; }
    public abstract void ModifyEffect(InteractionEffect effect);

}


public class Armour : Modifier
{
    public Armour(int armour)
    {
        Type = ModType.DamageReduction;
        Name = "Armour";
        DamageReduction = armour;
    }
    public int DamageReduction { get; set; }
    public override void ModifyEffect(InteractionEffect effect)
    {
        if (effect is DamageEffect damageEvent)
        {
            damageEvent.Damage -= DamageReduction;
            if (damageEvent.Damage < 0)
            {
                damageEvent.Damage = 0;
            }
            effect.Text = $"{effect.Target} reduces the damage by {DamageReduction} to just {damageEvent.Damage}.";
        }
    }
}
