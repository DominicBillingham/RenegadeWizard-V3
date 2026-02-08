using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Entities;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

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
