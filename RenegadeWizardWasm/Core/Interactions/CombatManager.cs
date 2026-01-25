
using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core.Interactions;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{

    public List<ActionContext> GetEnemyIntentions()
    {
        List<ActionContext> EnemyIntentions = new ();

        foreach (var ent in sceneManager.Npcs)
        {
            var random = new Random();
            GameAction action = ent.Actions[random.Next(ent.Actions.Count)];
            List<Entity> targets = action.NpcGetTargets(sceneManager.Entities);
            EnemyIntentions.Add(new ActionContext(ent, action, sceneManager.Entities, targets));
        }
        
        return EnemyIntentions;
    }
    
    public List<string> PlayRound()
    {
        List<string> CombatLines = new List<string>();
        
        ActionContext actionContext = new ActionContext(sceneManager.Player, inputManager.chosenAction, sceneManager.Entities, inputManager.Targets);
        string actionResult = actionContext.Resolve();
        CombatLines.Add(actionResult);
        
        
        
        
        sceneManager.RemoveDestroyedEntities();
        
        return CombatLines;

    }

}