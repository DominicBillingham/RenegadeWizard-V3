using RenegadeWizardWasm.Core.Enums;

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
