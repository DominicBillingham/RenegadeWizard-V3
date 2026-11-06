using RenegadeWizardWasm.Core.Interactions;

namespace RenegadeWizardWasm.Core.Statics;

public static class ActionList
{
    public static List<BaseAction> Actions { get; set; } = new();
    
    static ActionList()
    {
        Actions.Add(new Attack());
        Actions.Add(new Fireball());
    }
}