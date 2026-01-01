
namespace RenegadeWizardWasm.Core;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{
    public List<string> PlayRound()
    {
        List<string> CombatLines = new List<string>();

        Interaction interaction = new Interaction(sceneManager.Player, inputManager.chosenAction, sceneManager.Entities, inputManager.Targets);
        interaction.GetEffects();
        string actionResult = interaction.ApplyEffects();
        CombatLines.Add(actionResult);
            
        
        
        return CombatLines;

    }

}