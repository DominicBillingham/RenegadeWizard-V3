namespace RenegadeWizardWasm.Core.Enums;

public class InteractionResult()
{
    public string Text { get; set; } = "";
    public bool WasFailedAction { get; set; } = false;
}

public class Interaction(List<Entity> allEntities, List<Entity> chosenTargets, Entity actor, GameAction action)
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
    
    private readonly List<Entity> AllEntities = allEntities;
    private readonly List<Entity> ChosenTargets = chosenTargets;
    private Entity Actor { get; set; } = actor;
    private GameAction Action { get; set; } = action;

    public InteractionResult Resolve()
    {
        InteractionResult result = new();

        if (actor.Hitpoints <= 0)
        {
            result.Text = $"{actor.Name} is chilling in the underworld...";
            result.WasFailedAction = true;
            return result;
        }

        if (Action.UsesItem)
        {
            List<Entity> targets = GetActualTargets();

            if (targets.Count < 2)
            {
                result.Text = $"You need at least 2 targets to use an item. Targets selected: {targets.Count}";
                result.WasFailedAction = true;
                return result;
            }
            
            var item = targets.First();
            targets.Remove(item);
            
            foreach (Entity target in targets)
            {
                result.Text += $"{Action.Perform(Actor, target, item)}";
            }
        }
        else
        {
            foreach (Entity target in GetActualTargets())
            {
                result.Text += $"{Action.Perform(Actor, target)}";
            }
        }

        return result;
    }
    private List<Entity> GetActualTargets()
    {
        // This is creating a new LISTS but with the old class references.
        
        if (Action.TargetType == TargetType.Self) 
            return [Actor];
        
        if (Action.TargetType  == TargetType.All) 
            return [..AllEntities];
        
        if (Action.TargetType == TargetType.Single) 
            return [ChosenTargets.First()];
        
        return ChosenTargets;

    }
        
        
    
    
    
    
}