namespace RenegadeWizardWasm.Core;



public class Terminal(InputManager inputManager, SceneManager sceneManager, CombatManager combatManager)
{
    
    public TerminalResponse EnterInput(string playerInput)
    {
        inputManager.ProcessInput(playerInput);
        
        TerminalResponse terminalResponse = new TerminalResponse();
        terminalResponse.PlayerInput  = playerInput;

        if (inputManager.chosenAction == null) 
            return terminalResponse;
        
       // terminalResponse.Debug.Add($"Action: {inputManager.chosenAction?.Name ?? ""} | Targets: {string.Join(", ", inputManager.chosenAction?.Targets.Select(entity => entity.Name) ?? [])}" );
        
        terminalResponse.CombatLines.AddRange(combatManager.PlayRound());
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
            _text.Add(" ");
            _text.Add($"> {PlayerInput}");
            _text.AddRange(Debug);
            
            if (SceneLines.Any())
            {
                _text.Add(" ");
                _text.AddRange(CombatLines);
            }

            if (SceneLines.Any())
            {
                _text.Add(" ");
                _text.AddRange(SceneLines);
            }

            return _text;
        }
    }
    public string PlayerInput { get; set; }

    public List<string> Debug { get; set; } = new();
    public List<string> CombatLines { get; set; } = new();
    public List<string> SceneLines { get; set; } = new();


}