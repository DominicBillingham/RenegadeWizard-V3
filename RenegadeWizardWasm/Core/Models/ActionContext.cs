using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardWasm.Core.Models;

public class ActionContext
{
    // Actions will sometimes affect entities outside of the direct targets.
    // This class is used to provide everything an action needs info wise.
    
    // Before action is processed
    public IDiceRoller Roller { get; set; }
    public Entity Executor { get; set; }
    public List<Entity> IntendedTargets { get; set; }
    public List<Entity> AllEntities { get; set; }
    
    // During action being processed.
    DiceOutcome Roll { get; set; }
    
    
    public string Result { get; set; }
}