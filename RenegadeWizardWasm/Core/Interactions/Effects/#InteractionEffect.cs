using RenegadeWizardWasm.Core.Enums;
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


public class UseEffect : InteractionEffect
{
    public UseEffect(ActionContext context, Entity actor, Entity item) : base(context)
    {
        
        
    }
}