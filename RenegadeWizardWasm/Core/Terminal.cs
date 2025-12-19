namespace RenegadeWizardWasm.Core;




public class Terminal(InputManager inputManager)
{
    
    public void EnterInput(string playerInput)
    {
        inputManager.ProcessInput(playerInput);
    }
}



