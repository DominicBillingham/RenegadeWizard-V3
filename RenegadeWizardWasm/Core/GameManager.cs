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

        inputManager.ProcessInput(playerInput);
        roundResult.ChosenAction = inputManager.ChosenAction;
        
        
        // Process input
        // Find action
        // Find targets
        // Carry out player action
        // Carry out 
        
        
        
        roundResult.Entities = sceneManager.Entities ?? new List<Entity>();
        roundResult.rawUserInput += "FISH" + inputManager.ChosenAction.ToString();
        

        return roundResult;
    }
    
}