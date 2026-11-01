using Microsoft.JSInterop;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core;

public class GameManager(SceneManager sceneManager, InputManager inputManager)
{
    public RoundResult EnterInput(string playerInput)
    {
        RoundResult roundResult = new()
        {
            rawUserInput = playerInput
        };

        roundResult.rawUserInput += "FISH";
        
        roundResult.ChosenAction = inputManager.ChosenAction;

        return roundResult;
    }
    
}