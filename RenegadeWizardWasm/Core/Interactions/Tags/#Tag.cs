using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

public abstract class Tag
{
    public string Name { get; set; }
    public Duration Duration { get; set; } 

    public Tag(string name, Duration duration)
    {
        Name = name;
        Duration = duration;
    }
    public virtual void ModifyStats(Stat stat, ref int value)
    {
        
    }
    
    public virtual void StatusEffect(ActionContext context)
    {
        
    } 

}

public class Huge : Tag
{

    public Huge(string name, Duration duration) : base(name, duration)
    {
        Name = "Huge";
    }
    
    public override void ModifyStats(Stat stat, ref int value)
    {
        if (stat == Stat.Size) value += 3;
        if (stat == Stat.Weight) value += 3;
        if (stat == Stat.Strength) value += 3;
    }
    

}

public class Tenacious : Tag
{
    public Tenacious(string name, Duration duration) : base(name, duration)
    {
        Name = "Tenacious";
    }
}

public class Vulnerable : Tag
{
    public Vulnerable(string name, Duration duration) : base(name, duration)
    {
        Name = "Vulnerable";
    }
}

public class Immortal : Tag
{
    public Immortal(string name, Duration duration) : base(name, duration)
    {
        Name = "Immortal";
    }
}

public class Deflecting : Tag
{
    public Deflecting(string name, Duration duration) : base(name, duration)
    {
        Name = "Deflecting";
    }
}