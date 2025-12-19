namespace RenegadeWizardWasm.Core;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{
    public List<string> PlayRound()
    {
        List<string> CombatLines = new List<string>();

        CombatLines.AddRange(ResolveAction(sceneManager.Player, inputManager.chosenAction, inputManager.Targets));
        
        foreach (Entity entity in sceneManager.Npcs)
        {
            var random = new Random();
            var action = entity.Actions[random.Next(entity.Actions.Count)];
            var targets = new List<Entity> { sceneManager.Player };
            
            CombatLines.AddRange(ResolveAction(entity, action, targets));
        }
        
        return CombatLines;

    }
    
    private List<string> ResolveAction(Entity actor, GameAction action, List<Entity> Targets)
    {
        // To handle the complexity of state management and actions, it's best if:
        // Entities are purely data, and actions are purely data too.
        // Until they are fed into this service, which can then apply all the side effects.
        
        List<string> actionLines = new List<string>();

        foreach (Entity target in Targets)
        {
            if (action.Damage is { } damage)
            {
                target.Hitpoints -= damage;
                actionLines.Add($"{actor.Name} <powerfully> attacks {target.Name} for {damage}hp");
            }

            if (action.Heal is { } heal)
            {
                target.Hitpoints += heal;
                actionLines.Add($"{target.Name} healed {heal} hitpoints from {actor.Name}.");
            }
        }

        return actionLines;
    }
    
    
}