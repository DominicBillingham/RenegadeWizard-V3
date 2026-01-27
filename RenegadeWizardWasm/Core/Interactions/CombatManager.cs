using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core.Interactions;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{
    public int CombatRoundCount { get; set; } = 0;
    private List<ActionContext> EnemyIntentions { get; set; } = new();
    
    public List<string> StartCombat()
    {
        CombatRoundCount = 1;
        RefreshNpcsIntentions();
        return ReadEnemyIntentions();
    }
    
    public List<string> PlayRound()
    {
        List<string> CombatLines = new List<string>();
        
        ActionContext actionContext = new ActionContext(sceneManager.Player, inputManager.chosenAction, sceneManager.Entities, inputManager.Targets);
        string actionResult = actionContext.Resolve();
        CombatLines.Add(actionResult);

        if (actionContext.AllowRetry)
        {
            return CombatLines;
        }
        
        sceneManager.RemoveDestroyedEntities();
        RefreshNpcsIntentions();
        CombatLines.AddRange(ReadEnemyIntentions());
        CombatRoundCount++;
        
        return CombatLines;
    }
    
    public List<string> ReadEnemyIntentions()
    {
        List<string> actionList = new();
        foreach (var context in EnemyIntentions)
        {
            string targetList = string.Join(", ", context.IntendedTargets.Select(x => x.Name));
            string action = context.GameAction.Name;
            actionList.Add($"{context.Actor.Name} intends to {action} at {targetList}");
        }   
        return actionList;
    }
    
    public void RefreshNpcsIntentions()
    {
        EnemyIntentions.Clear();
        foreach (var ent in sceneManager.Npcs)
        {
            var random = new Random();
            GameAction action = ent.Actions[random.Next(ent.Actions.Count)];
            List<Entity> targets = action.NpcGetTargets(sceneManager.Entities);
            EnemyIntentions.Add(new ActionContext(ent, action, sceneManager.Entities, targets));
        }
    }

}