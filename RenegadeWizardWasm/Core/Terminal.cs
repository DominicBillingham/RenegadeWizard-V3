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
        terminalResponse.SceneLines.AddRange(sceneManager.GetSceneDescription());
        return terminalResponse;
    }
    
}


public class TerminalResponse()
{
    // This get is used to format the list of strings for the terminal
    // This way, strings can be added in any order and still formatted correctlys
    public List<string> Text
    {
        get
        {
            List<string> _text = new List<string>();

            if (string.IsNullOrWhiteSpace(PlayerInput) == false)
            {
                _text.Add(" ");
                _text.Add($"> {PlayerInput}");
            }

            if (DebugLines.Any())
            {
                _text.AddRange(DebugLines);
            }
            
            if (SceneLines.Any())
            {
                _text.AddRange(CombatLines);
            }

            if (SceneLines.Any())
            { _text.AddRange(SceneLines);
            }

            return _text;
        }
    }

    public string PlayerInput { get; set; } = "";
    public List<string> DebugLines { get; set; } = new();
    public List<string> CombatLines { get; set; } = new();
    public List<string> SceneLines { get; set; } = new();

    public List<Entity> Objects = new();
    public List<Entity> Creatures = new();
    





}