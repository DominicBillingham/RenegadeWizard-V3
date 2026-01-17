
using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core.Interactions;

public class CombatManager(SceneManager sceneManager, InputManager inputManager)
{
    public List<string> PlayRound()
    {
        List<string> CombatLines = new List<string>();
        Interaction interaction = new Interaction(sceneManager.Player, inputManager.chosenAction, sceneManager.Entities, inputManager.Targets);
        string actionResult = interaction.Resolve();
        CombatLines.Add(actionResult);
        return CombatLines;

    }

}