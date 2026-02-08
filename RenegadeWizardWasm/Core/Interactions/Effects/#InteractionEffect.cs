using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Entities;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public abstract class InteractionEffect
{
    public string Result { get; set; } = "";
    public bool HideResult { get; set; } = false;
    
    public InteractionEffect(ActionContext context)
    {
        context.CombatLog.Add(this);
    }
    
}


public class ApplyStatusEffect : InteractionEffect
{
    public ApplyStatusEffect(ActionContext context, Entity target, Tag tag) : base(context)
    {
        if (tag.HostilityScale == HostilityScale.Neutral)
        {
            Result = $"{target.Name} gained the {tag.Name} status.";
            Result = $"{tag.Name} was applied to {target.Name}.";
            Result = $"{target.Name} received {tag.Name}.";
        }
        else if (tag.HostilityScale == HostilityScale.Friendly)
        {
            Result = $"{target.Name} has been blessed with {tag.Name}.";
            Result = $"{target.Name} enchanted with {tag.Name}.";
            Result = $"{target.Name} has been given {tag.Name}.";
        }
        else if (tag.HostilityScale == HostilityScale.Aggressive)
        {
            Result = $"{target.Name} has been afflicted with {tag.Name}.";
            Result = $"{target.Name} suffers from {tag.Name}.";
            Result = $"{target.Name} is now cursed by {tag.Name}.";
        }
        target.Tags.Add(tag);
    }
}


public class UseEffect : InteractionEffect
{
    public UseEffect(ActionContext context, Entity actor, Entity item) : base(context)
    {
        
        
    }
}