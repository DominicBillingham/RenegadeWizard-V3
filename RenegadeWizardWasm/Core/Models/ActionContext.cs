using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Errors;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardWasm.Core.Models;

public class ActionContext
{
    // Actions will sometimes affect entities outside of the direct targets.
    // This class is used to provide everything an action needs info wise.
    
    // Before action is processed
    public required IDiceRoller Roller { get; set; }
    public required Entity Executor { get; set; }
    public required List<Entity> IntendedTargets { get; set; }
    public required List<Entity> AllEntities { get; set; }
    
    
    public string Result { get; set; }
    
}