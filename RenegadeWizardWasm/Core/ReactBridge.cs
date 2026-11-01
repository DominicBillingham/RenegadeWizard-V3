using Microsoft.JSInterop;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core;

public static class ReactBridge
{
    private static GameManager? _gameManager;

    public static void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    [JSInvokable]
    public static RoundResult EnterInput(string playerInput)
    {
        if (_gameManager == null)
        {
            throw new InvalidOperationException("ReactBridge not initialized.");
        }
        return _gameManager.EnterInput(playerInput);
    }
    
}
