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

public class Burning : Tag
{
    
    public Entity target;
    
    public Burning(Duration duration) : base(duration)
    {
        Name = "Burning";
    }

    public override void StatusEffect(ActionContext context)
    {
        
        
    }
}


public class Huge : Tag
{
    public Huge(Duration duration) : base(duration)
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


public class Attached : Tag
{
    public Entity? AttachedTo { get; set; }
    public int AttachmentStrength { get; set; }
    
    public Attached(Duration duration, int attachmentStrength, Entity? attachedTo = null) : base(duration)
    {
        Name = "Attached";
        AttachedTo = attachedTo;
        AttachmentStrength = attachmentStrength;
    }
}


public class Tenacious : Tag
{
    public Tenacious(Duration duration) : base(duration)
    {
        Name = "Tenacious";
    }
}

public class Vulnerable : Tag
{
    public Vulnerable(Duration duration) : base(duration)
    {
        Name = "Vulnerable";
    }
}

public class Immortal : Tag
{
    public Immortal(Duration duration) : base(duration)
    {
        Name = "Immortal";
    }
}

public class Deflecting : Tag
{
    public Deflecting(Duration duration) : base(duration)
    {
        Name = "Deflecting";
    }
}

public class FallHazard : Tag
{
    public FallHazard(Duration duration) : base(duration)
    {
        Name = "FallHazard";
    }
}

public class Terrified : Tag
{
    public Terrified(Duration duration) : base(duration)
    {
        Name = "Terrified";
    }
}