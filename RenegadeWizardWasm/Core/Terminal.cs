namespace RenegadeWizardWasm.Core;


// Goals
// 1. Allow the user input to queue up an action
// 2. Allow the action to damage a goblin
// 3. Allow the goblin to attack
// 4. Add the healing spell

public class Terminal(InputManager inputManager, ActionResolver actionResolver)
{
    
    public TerminalResponse EnterInput(string playerInput)
    {
        inputManager.ProcessInput(playerInput);
        
        TerminalResponse terminalResponse = new TerminalResponse();
        terminalResponse.PlayerInput  = playerInput;


        if (inputManager.chosenAction == null) 
            return terminalResponse;
        
        terminalResponse.Debug.Add($"Action: {inputManager.chosenAction?.Name ?? ""} | Targets: {string.Join(", ", inputManager.chosenAction?.Targets.Select(entity => entity.Name) ?? [])}" );
        
        List<string> results = actionResolver.ResolveAction(inputManager.chosenAction);
        terminalResponse.ActionLines.AddRange(results);
        
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
            _text.Add($"> {PlayerInput}");
            
            #if DEBUG
            _text.AddRange(Debug);
            #endif
            
            _text.AddRange(ActionLines);
            
            return _text;
        }
    }
    public string PlayerInput { get; set; }

    public List<string> Debug { get; set; } = new();

    public List<string> ActionLines { get; set; } = new();


}