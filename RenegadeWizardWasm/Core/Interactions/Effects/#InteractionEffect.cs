using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Entities;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public abstract class InteractionEffect
{
    public ActionContext Context { get; set; }
    public string Result { get; set; } = "";
    public bool HideResult { get; set; } = false;
    
    public InteractionEffect(ActionContext context)
    {
        context.CombatLog.Add(this);
        Context = context;
    }
    
}


public class ApplyStatusEffect : InteractionEffect
{
    public ApplyStatusEffect(ActionContext context, Entity target, Tag tag) : base(context)
    {
        target.Tags.Add(tag);
        Result = $"{target.Name} is now {tag.Name}.";
    }
}


public class UseEffect : InteractionEffect
{
    public UseEffect(ActionContext context, Entity actor, Entity item) : base(context)
    {
        
        
    }
}