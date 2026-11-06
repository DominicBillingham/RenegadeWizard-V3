using Microsoft.JSInterop;
using RenegadeWizardWasm.Core.Interactions;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Statics;
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

        inputManager.ProcessInput(playerInput);
        
        if  (inputManager.ChosenAction == null)
        {
            roundResult.ErrorMessage = "No action chosen";
            return roundResult;
        }
        
        roundResult.ChosenActionId = inputManager.ChosenAction;
        roundResult.ChosenTargets = inputManager.ChosenTargets;
        
        
        
        
        roundResult.Entities = sceneManager.Entities ?? new List<Entity>();
        roundResult.rawUserInput += "FISH" + inputManager.ChosenAction.ToString();
        

        return roundResult;
    }
    
}