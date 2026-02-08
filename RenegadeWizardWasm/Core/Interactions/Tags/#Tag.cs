using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

public abstract class Tag
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Duration Duration { get; set; }
    public bool AppliedThisRound { get; set; } = true;

    public DisplayPriority DisplayPriority { get; set; } = DisplayPriority.Normal;


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
        Description = $"Any entity with the explosive damage will explode when they reach 0 hit points.";
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

public class Mechanical : Tag
{
    public Mechanical(Duration duration) : base(duration)
    {
        Name = "Mechanical";
        DisplayPriority = DisplayPriority.Low;
    }
}

public class Organic : Tag
{
    public Organic(Duration duration) : base(duration)
    {
        Name = "Organic";
        DisplayPriority = DisplayPriority.Low;
    }
}
