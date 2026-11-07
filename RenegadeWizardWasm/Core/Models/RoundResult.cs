using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Models;

public class RoundResult
{
    
    // UI Elements
    public string rawUserInput { get; set; }
    public List<ActionIdentity> PossibleActions { get; set; } = new();
    public List<string> PossibleTargets => Entities.Select(e => e.Name).ToList();
    public string? ErrorMessage { get; set; }
    
    // Round Calculations
    public ActionId? ChosenActionId { get; set; }
    public List<Entity> ChosenTargets { get; set; } = new();
    public List<ActionResult> ActionResults { get; set; } = new();
    
    public List<Entity> Entities { get; set; } = new();
    

    
    // This is a single object that gathers all the results of a single round.
    // It will then return this information to the user interface..

}

public class ActionResult
{
    
}