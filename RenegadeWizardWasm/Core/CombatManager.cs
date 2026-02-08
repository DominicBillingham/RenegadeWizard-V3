using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.Interactions;
using RenegadeWizardWasm.Core.Interactions.Actions;
using RenegadeWizardWasm.Core.Interactions.Entities;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{
    public int CombatRoundCount { get; set; } = 0;
    public void StartCombat()
    {
        CombatRoundCount = 1;
        RefreshNpcsIntentions();
    }
    
    public List<string> NextRound()
    {
        List<string> CombatLines = new List<string>();
        
        ActionContext actionContext = new ActionContext(sceneManager.Player, inputManager.chosenAction, sceneManager.Entities, inputManager.Targets);
        actionContext.Resolve();
        CombatLines.Add(actionContext.Result);

        if (actionContext.AllowRetry)
        {
            return CombatLines;
        }

        foreach (Entity ent in sceneManager.Npcs)
        {
            if (ent.IntendedAction == null) continue;
            ent.IntendedAction.Resolve();
            CombatLines.Add(ent.IntendedAction.Result);
            ent.IntendedAction = null;
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
        foreach (var ent in sceneManager.Npcs)
        {
            var random = new Random();
            GameAction action = ent.Actions[random.Next(ent.Actions.Count)];
            List<Entity> targets = action.NpcGetTargets(sceneManager.Entities);
            ent.IntendedAction = new ActionContext(ent, action, sceneManager.Entities, targets);
        }
    }

}