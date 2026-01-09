namespace RenegadeWizardWasm.Core;


public abstract class Modifier
{
    public string Name { get; set; } = "";
    public abstract void ModifyEffect(InteractionEffect effect);

}


public class Armour : Modifier
{
    public Armour(int armour)
    {
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
            effect.Result += $"{effect.Target.Name} reduces damage by {DamageReduction}.";
        }
    }
}
