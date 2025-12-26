
namespace RenegadeWizardWasm.Core;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{
    public List<string> PlayRound()
    {
        List<string> CombatLines = new List<string>();

        GameActionResult result = inputManager.chosenAction.Resolve(sceneManager.Player, sceneManager.Entities, inputManager.Targets);
        CombatLines.Add(result.Text);
        
        if (result.AllowRetry)
            return CombatLines;
        
        foreach (Entities entity in sceneManager.Npcs)
        {
            var random = new Random();
            var action = entity.Actions[random.Next(entity.Actions.Count)];
            var targets = new List<Entities> { sceneManager.Player };
            
        }
        
        return CombatLines;

    }

}