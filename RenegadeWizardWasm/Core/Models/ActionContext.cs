using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardWasm.Core.Models;

public class ActionContext
{
    // Actions will sometimes affect entities outside of the direct targets.
    // This class is used to provide everything an action needs info wise.
    
    public IDiceRoller Roller { get; set; }
    public Entity Executor { get; set; }
    public List<Entity> IntendedTargets { get; set; }
    public List<Entity> AllEntities { get; set; }
    public string Result { get; set; }
}