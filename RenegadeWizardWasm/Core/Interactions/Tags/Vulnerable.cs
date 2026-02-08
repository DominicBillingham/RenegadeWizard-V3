using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

public class Vulnerable : Tag
{
    public Vulnerable(Duration duration) : base(duration)
    {
        Name = "Vulnerable";
        HostilityScale = HostilityScale.Aggressive;
    }
}
