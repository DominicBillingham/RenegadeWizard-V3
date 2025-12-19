namespace RenegadeWizardWasm.Core;


// Goals
// 1. Allow the user input to queue up an action
// 2. Allow the action to damage a goblin
// 3. Allow the goblin to attack
// 4. Add the healing spell

public class Terminal(InputManager inputManager)
{
    
    public TerminalResponse EnterInput(string playerInput)
    {
        inputManager.ProcessInput(playerInput);
        
        TerminalResponse terminalResponse = new TerminalResponse();
        terminalResponse.PlayerInput  = playerInput;
        
        terminalResponse.Debug.Add($"Action: {inputManager.chosenAction?.Name ?? ""}" );
        terminalResponse.Debug.Add($"Targets: {string.Join(", ", inputManager.targets.Select(entity => entity.Name))}");
        
        return terminalResponse;
    }
}


public class TerminalResponse()
{
    // This get is used to format the list of strings for the terminal
    public List<string> Text
    {
        get
        {
            List<string> _text = new List<string>();
            _text.Add(" ");
            _text.Add($"> PlayerResponse");
            
            #if DEBUG
            _text.AddRange(Debug);
            #endif
            
            return _text;
        }
    }
    public string PlayerInput { get; set; }

    public List<string> Debug { get; set; } = new();
    

}