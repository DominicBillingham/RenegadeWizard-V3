namespace RenegadeWizardWasm.Core;

public abstract class Mod
{
    public string Name { get; set; } = "";
    
    public int Duration { get; set; }
    
    public int Priority { get; set; } = 0;

    public virtual void ModifyEvent(InteractionEvent gameEvent) 
    {
        
    }
    
}


