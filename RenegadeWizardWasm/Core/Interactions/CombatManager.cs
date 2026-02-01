using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core.Interactions;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{
    public int CombatRoundCount { get; set; } = 0;
    private List<ActionContext> EnemyIntentions { get; set; } = new();
    
    public void StartCombat()
    {
        CombatRoundCount = 1;
        RefreshNpcsIntentions();
    }
    
    public List<string> PlayRound()
    {
        List<string> CombatLines = new List<string>();
        
        ActionContext actionContext = new ActionContext(sceneManager.Player, inputManager.chosenAction, sceneManager.Entities, inputManager.Targets);
        actionContext.Resolve();
        CombatLines.Add(actionContext.Result);

        if (actionContext.AllowRetry)
        {
            return CombatLines;
        }

        foreach (var intent in EnemyIntentions)
        {
            intent.Resolve();
            CombatLines.Add(intent.Result);
            if (intent.Actor != null) intent.Actor.IntentionIcon = null;
        }
        
        sceneManager.RemoveDestroyedEntities();

        if (sceneManager.Npcs.Count == 0)
        {
            CombatLines.Add("All enemies have been defeated!");
            return CombatLines;
        }
        
        RefreshNpcsIntentions();
        CombatRoundCount++;
        
        return CombatLines;
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
            ent.IntentionIcon = action.Icon;
        }
    }

}