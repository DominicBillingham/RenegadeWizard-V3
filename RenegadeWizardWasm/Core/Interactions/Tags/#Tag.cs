using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

public abstract class Tag
{
    public string Name { get; set; }
    public Duration Duration { get; set; } 

    public Tag(Duration duration)
    {
        Duration = duration;
    }
    public virtual void ModifyStats(Stat stat, ref int value)
    {
        
    }
    
    public virtual void StatusEffect(ActionContext context)
    {
        
    } 

}

public class Explosive : Tag
{
    public int Damage { get; set; } 
    public Explosive(Duration duration, int damage) : base(duration)
    {
        Name = "Explosive";
        Damage = damage;
    }
}

public class Immovable : Tag
{
    public Immovable(Duration duration) : base(duration)
    {
        Name = "Immovable";
    }
}
