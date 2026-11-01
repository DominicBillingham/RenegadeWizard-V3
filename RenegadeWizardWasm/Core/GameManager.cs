using Microsoft.JSInterop;
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
        return roundResult;
    }
    
}