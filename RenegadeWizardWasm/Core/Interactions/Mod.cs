namespace RenegadeWizardWasm.Core;

public abstract class Mod
{
    public string Name { get; set; } = "";
    
    public int Duration { get; set; }
    
    public int Priority { get; set; } = 0;

    public virtual void ModifyEvent(InteractionEvent gameEvent) 
    {
        
    }
    
}


public class Armour : Mod
{
    public int DamageReduction { get; set; }
    public override void ModifyEvent(InteractionEvent gameEvent)
    {
        if (gameEvent is DamageEvent damageEvent)
        {
            damageEvent.Damage -= DamageReduction;
            if (damageEvent.Damage < 0)
            {
                damageEvent.Damage = 0;
            }
            damageEvent.Text += $"({Name} reduces the damage by {DamageReduction} to {damageEvent.Damage})";
        }
    }
}
