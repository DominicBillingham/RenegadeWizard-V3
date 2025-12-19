namespace RenegadeWizardWasm.Core;




public class Terminal(InputManager inputManager)
{
    
    public TerminalResponse EnterInput(string playerInput)
    {
        inputManager.ProcessInput(playerInput);
        
        TerminalResponse terminalResponse = new TerminalResponse();
        terminalResponse.Text.Add(inputManager.rawInput);

        return terminalResponse;
    }
}


public class TerminalResponse()
{
    public List<string> Text { get; set; } = new();
}
