using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

public class Huge : Tag
{
    public Huge(Duration duration) : base(duration)
    {
        Name = "Huge";
        HostilityScale = HostilityScale.Friendly;
    }
    
    public override void ModifyStats(Stat stat, ref int value)
    {
        if (stat == Stat.Size) value += 3;
        if (stat == Stat.Weight) value += 3;
        if (stat == Stat.Strength) value += 3;
    }
}
