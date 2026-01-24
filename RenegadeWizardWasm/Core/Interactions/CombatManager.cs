
using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core.Interactions;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{

    public List<Interaction> GetEnemyIntentions()
    {
        List<Interaction> EnemyIntentions = new ();

        foreach (var ent in sceneManager.Npcs)
        {
            var random = new Random();
            GameAction action = ent.Actions[random.Next(ent.Actions.Count)];
            List<Entity> targets = action.NpcGetTargets(sceneManager.Entities);
            EnemyIntentions.Add(new Interaction(ent, action, sceneManager.Entities, targets));
        }
        
        return EnemyIntentions;
    }
    
    public List<string> PlayRound()
    {
        List<string> CombatLines = new List<string>();
        
        Interaction interaction = new Interaction(sceneManager.Player, inputManager.chosenAction, sceneManager.Entities, inputManager.Targets);
        string actionResult = interaction.Resolve();
        CombatLines.Add(actionResult);
        
        
        
        
        sceneManager.RemoveDestroyedEntities();
        
        return CombatLines;

    }

}