using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Entities;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

public class Burning : Tag
{
    
    public Entity target;
    
    public Burning(Duration duration) : base(duration)
    {
        Name = "Burning";
        Description = "The target is on fire and suffers damage over time.";
        HostilityScale = HostilityScale.Aggressive;
    }

    public override void StatusEffect(ActionContext context)
    {
        
        
    }
}
