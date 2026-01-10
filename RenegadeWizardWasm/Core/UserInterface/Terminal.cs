namespace RenegadeWizardWasm.Core;



public class Terminal(InputManager inputManager, SceneManager sceneManager, CombatManager combatManager)
{
    
    public TerminalResponse EnterInput(string playerInput)
    {
        TerminalResponse terminalResponse = GetBaseText();
        
        inputManager.ProcessInput(playerInput);
        terminalResponse.PlayerInput  = playerInput;

        if (inputManager.chosenAction == null) 
            return terminalResponse;
        
        terminalResponse.DebugLines.Add($"Action: {inputManager.chosenAction?.Name ?? ""} | Targets: {string.Join(", ", inputManager.Targets.Select(entity => entity.Name) ?? [])}" );
        terminalResponse.CombatLines.AddRange(combatManager.PlayRound());
        
        return terminalResponse;
    }

    public TerminalResponse GetBaseText()
    {
        TerminalResponse terminalResponse = new TerminalResponse();
        terminalResponse.Creatures = sceneManager.Npcs;
        terminalResponse.Objects = sceneManager.Objects;
        
        terminalResponse.ActionNames = sceneManager.Player.Actions.Select(action => action.Name.ToLower()).ToList();
        terminalResponse.EntityNames = sceneManager.Entities.Select(entity => entity.Name.ToLower()).ToList();
        
        terminalResponse.SceneLines.AddRange(sceneManager.GetSceneDescription());
        return terminalResponse;
    }
    
}

