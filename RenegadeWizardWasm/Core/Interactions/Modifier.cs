using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions;


public abstract class Modifier
{
    public string Name { get; set; } = "";
    public abstract void ModifyEffects(InteractionEffect effect);

    public virtual void ModifyStats(Stat stat, ref int statValue)
    {
        
    }

}
