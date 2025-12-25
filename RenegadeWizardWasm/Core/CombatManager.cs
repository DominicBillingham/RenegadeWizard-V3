using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{
    public List<string> PlayRound()
    {
        List<string> CombatLines = new List<string>();
        
        
        Interaction playerInteraction = new Interaction(sceneManager.Entities, inputManager.Targets, sceneManager.Player, inputManager.chosenAction);
        CombatLines.Add(playerInteraction.Resolve());
        
        foreach (Entity entity in sceneManager.Npcs)
        {
            var random = new Random();
            var action = entity.Actions[random.Next(entity.Actions.Count)];
            var targets = new List<Entity> { sceneManager.Player };
            
        }
        
        return CombatLines;

    }

}