namespace RenegadeWizardWasm.Core.Interactions;

public abstract class InteractionEffect
{
    public required Entity Target { get; set; }
    public required Entity Actor { get; set; }
    public required Interaction Context { get; set; }
    public string Result { get; set; } = "";
    public bool HideResult { get; set; } = false;

    public void Apply()
    {
        Context.EffectLog.Add(this);
        
        foreach (var mod in Actor.Boosters)
        {
            mod.ModifyEffect(this);
        }

        foreach (var mod in Target.Modifiers)
        {
            mod.ModifyEffect(this);
        }

        if (Target.Replacer != null)
        {
            Target.Replacer.ModifyEffect(this);
            return;
        }
        
        Core();
        
    }
    protected abstract void Core();
}




