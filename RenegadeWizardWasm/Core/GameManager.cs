using Microsoft.JSInterop;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core;

public static class GameManager
{
    [JSInvokable]
    public static RoundResult EnterInputStatic(string playerInput)
    {
        RoundResult roundResult = new()
        {
            rawUserInput = playerInput
        };
        
        roundResult.ChosenAction = InputManager.chosenAction;

        return roundResult;
    }

    public static void StartGame()
    {
        SceneManager.Entities.Add(new Entity()
        {
            Name = "Player",
            Description = "A potato.",
            IsPlayer = true
        });
        
        
    }
    
}