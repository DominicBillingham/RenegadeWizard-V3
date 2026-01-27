using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

public class FallHazard : Tag
{
    public FallHazard(Duration duration) : base(duration)
    {
        Name = "FallHazard";
    }
}
