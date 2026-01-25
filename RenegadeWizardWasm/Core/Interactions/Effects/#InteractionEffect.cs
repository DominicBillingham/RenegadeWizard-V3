using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions;

public abstract class InteractionEffect
{
    public ActionContext Context { get; set; }
    public string Result { get; set; } = "";
    public bool HideResult { get; set; } = false;
    
    public InteractionEffect(ActionContext context)
    {
        context.CombatLog.Add(this);
    }
    
}

