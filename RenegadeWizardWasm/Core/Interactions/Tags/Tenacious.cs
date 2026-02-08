using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

public class Tenacious : Tag
{
    public Tenacious(Duration duration) : base(duration)
    {
        Name = "Tenacious";
        HostilityScale = HostilityScale.Friendly;
    }
}
