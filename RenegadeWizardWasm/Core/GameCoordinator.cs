using Microsoft.JSInterop;
using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.Interactions;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardWasm.Core;

public enum GameState
{
    LevelSelect,
    Combat,
    PerkSelect,
    Conversation,
    NameSelect,
    Introduction,
}
public class GameCoordinator(InputManager inputManager, SceneManager sceneManager, CombatManager combatManager)
{
    private static GameCoordinator? _instance;

    public static void Initialize(GameCoordinator instance)
    {
        _instance = instance;
    }

    [JSInvokable]
    public static GameResponse StartGameStatic()
    {
        if (_instance == null)
        {
            throw new InvalidOperationException("GameCoordinator not initialized.");
        }
        return _instance.StartGame();
    }

    [JSInvokable]
    public static GameResponse EnterInputStatic(string playerInput)
    {
        if (_instance == null)
        {
            throw new InvalidOperationException("GameCoordinator not initialized.");
        }
        return _instance.EnterInput(playerInput);
    }

    private GameState GameState { get; set; } = GameState.Combat;

    public GameResponse StartGame()
    {
        // This should be the only other place where GameResponse is created.
        GameResponse gameResponse = new();
        // StaticResponses.BeginGame(gameResponse);
        // GameState = GameState.NameSelect;
        return PopulateTerminal(gameResponse);
    }
    
    public GameResponse EnterInput(string playerInput)
    {
        
        GameResponse gameResponse = new();
        
        inputManager.ProcessInput(playerInput);
        gameResponse.PlayerInput  = playerInput;

        if (string.IsNullOrWhiteSpace(playerInput) || inputManager.chosenAction == null)
        {
            return PopulateTerminal(gameResponse);
        }
        
        if (GameState == GameState.NameSelect)
        {
            sceneManager.Player.Name = playerInput;
            StaticResponses.EnterName(gameResponse, playerInput);
            
            GameState = GameState.Combat;
            return PopulateTerminal(gameResponse);
        }
        
        if (GameState == GameState.Combat)
        {
            if (combatManager.CombatRoundCount > 0)
            {
                gameResponse.CombatLines.AddRange(combatManager.NextRound());
            }
            else
            {
                sceneManager.Level1();
                combatManager.StartCombat();
                gameResponse.CombatLines.AddRange(combatManager.NextRound());
            }
        }
        
        return PopulateTerminal(gameResponse);
    }
    
    public GameResponse PopulateTerminal(GameResponse gameResponse)
    {
        gameResponse.CreatureCards = sceneManager.Actors.Select(entity => new TerminalCard(entity)).ToList();
        gameResponse.ObjectCards = sceneManager.Objects.Select(entity => new TerminalCard(entity)).ToList();
        gameResponse.ActionNames = sceneManager.Player.Actions.Select(action => action.Name.ToLower()).ToList();
        gameResponse.EntityNames = sceneManager.Entities.Select(entity => entity.Name.ToLower()).ToList();

        // Convert narration/combat lines to HTML using MiniMarkup
        // This makes it easier for the React front-end to render styled text
        var allText = gameResponse.GetFormattedText();
        gameResponse.Text = allText.Select(line => MiniMarkup.ConvertString(line)).ToList();
        
        return gameResponse;
    }
    
    
    
}