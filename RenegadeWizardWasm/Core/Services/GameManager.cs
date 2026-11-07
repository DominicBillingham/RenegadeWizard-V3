using RenegadeWizardWasm.Core.Errors;
using RenegadeWizardWasm.Core.Interactions.Actions;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Statics;

namespace RenegadeWizardWasm.Core.Services;

public class GameManager(SceneManager sceneManager, InputManager inputManager, IDiceRoller diceRoller)
{
    // This is the high-level orchestrator of the game.
    // The only error handling is found here, as it should decide what happens when an error occurs.
    // Since a single input can cause a variety of fields to update, we are going to build a RoundResult object to hold all the information we need to update the game state.
    // Then the round result object can format all the data and return it to whichever front end we hook into.
    // Also designed so that we could rip off the front end and replace it.
    
    public RoundResult EnterInput(string playerInput)
    {
        RoundResult roundResult = new()
        {
            rawUserInput = playerInput
        };

        inputManager.ProcessInput(playerInput);
        
        if (inputManager.ChosenAction == null)
        {
            roundResult.ErrorMessage = "No action chosen";
            return roundResult;
        }
        
        roundResult.ChosenActionId = inputManager.ChosenAction;
        roundResult.ChosenTargets = inputManager.ChosenTargets;
        
        // Perform the player's action.
        try
        {
            var context = new ActionContext
            {
                Roller = diceRoller,
                Executor = sceneManager.GetPlayer,
                IntendedTargets = inputManager.ChosenTargets
            };
            BaseAction action = ActionReg.GetAction(inputManager.ChosenAction.Value);
            action.Execute(context);
        }
        catch (BadInputException ex) // Custom error specifically for us to be able to throw / catch
        {
            roundResult.ErrorMessage = ex.Message;
            return roundResult;
        }
        catch (Exception ex)
        {
            roundResult.ErrorMessage = "Something weird has happened! Contact the developer to complain!";
            return roundResult;
        }
        
        // Perform each NPC's action after 
        try 
        {
            
        }
        catch
        {
            // If an NPC is confused, skip their turn.
        }

        return roundResult;
    }
    
}