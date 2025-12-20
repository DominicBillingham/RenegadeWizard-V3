namespace RenegadeWizardWasm.Core.Enums;

public class Interaction(List<Entity> allEntities, List<Entity> chosenTargets, Entity actor, GameAction action, Entity? item = null)
{
    // Interaction is the fundamental core of the game.
    // All data flows into this class, then this runs the logic and applies any side effects.
    // As such, it's the only place that can store temporary data (like actual targets).
    
    // Data that flows into the class:
    // GameActions describe purely the effect of the action on a per-target basis. 
    // Entities contain data about the target and actor, like HP or status effects.
    
    // order of execution:
    // First the interaction resolves which entities will be affected.
    // Then it will apply the effects of the action to every single entity.
    private List<Entity> AllEntities { get; set; } = allEntities;
    private List<Entity> ChosenTargets { get; set; } = chosenTargets;
    private Entity Actor { get; set; } = actor;
    private GameAction Action { get; set; } = action;
    private Entity? Item { get; set; } = item;

    public string Resolve()
    {
        string result = "";
        foreach (Entity target in GetActualTargets())
        {
            result += $" {Action.Effect(Actor, target, Item)}";
        }
        return result;
    }
    private List<Entity> GetActualTargets()
    {
        if (Action.TargetType == TargetType.Self) 
            return [Actor];
        
        if (Action.TargetType  == TargetType.All) 
            return AllEntities;
        
        if (Action.TargetType == TargetType.Single) 
            return [ChosenTargets.First()];
        
        // This is a fallback for safety reasons. Ideally this shouldn't trigger.
        return ChosenTargets;

    }
        
        
    
    
    
    
}