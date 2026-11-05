using RenegadeWizardWasm.Core.Interactions;

namespace RenegadeWizardWasm.Core.Statics;

public class ActionList
{
    private List<BaseAction> actions { get; set; } = new();
    
    ActionList()
    {
        actions.Add(new Attack());
        
        
        
    }
}