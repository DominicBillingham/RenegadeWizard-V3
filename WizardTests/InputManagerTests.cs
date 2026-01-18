using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.Entities;
using RenegadeWizardWasm.Core.UserInterface;
using Xunit;

namespace WizardTests;

public class InputManagerTests
{
    [Fact]
    public void ExactMatch()
    {
        // Arrange
        var sceneManager = new SceneManager();
        var inputManager = new InputManager(sceneManager);
        var userInput = "punch goblin";

        // Act
        inputManager.ProcessInput(userInput);

        // Assert
        Assert.NotNull(inputManager.chosenAction);
        Assert.Equal("Punch", inputManager.chosenAction.Name);
    }

    [Fact]
    public void NameFuzzyMatch()
    {
        // Arrange
        var sceneManager = new SceneManager();
        var inputManager = new InputManager(sceneManager);
        var userInput = "punsh goblin"; // Typo in action

        // Act
        inputManager.ProcessInput(userInput);

        // Assert
        Assert.NotNull(inputManager.chosenAction);
        Assert.Equal("Punch", inputManager.chosenAction.Name);
    }

    [Fact]
    public void TargetOrder()
    {
        // Arrange
        var sceneManager = new SceneManager();
        var inputManager = new InputManager(sceneManager);
        // In SceneManager: Door is added first, then Player, then Goblin, then Adam, then IronGolem, then Table, then Chair
        // Input order: table chair goblin
        var userInput = "punch table chair goblin";

        // Act
        inputManager.ProcessInput(userInput);

        // Assert
        Assert.Equal(3, inputManager.Targets.Count);
        Assert.Equal("Table", inputManager.Targets[0].Name);
        Assert.Equal("Chair", inputManager.Targets[1].Name);
        Assert.Equal("Goblin", inputManager.Targets[2].Name);
    }
    
    [Fact]
    public void TargetOrderThrow()
    {
        // Arrange
        var sceneManager = new SceneManager();
        var inputManager = new InputManager(sceneManager);
        // In SceneManager: Door is added first, then Player, then Goblin, then Adam, then IronGolem, then Table, then Chair
        // Input order: table chair goblin
        var userInput = "I throw the adam at the door";

        // Act
        inputManager.ProcessInput(userInput);

        // Assert
        Assert.Equal("Adam", inputManager.Targets[0].Name);
        Assert.Equal("Door", inputManager.Targets[1].Name);
    }
    
    [Fact]
    public void AkaFuzzyMatch()
    {
        // Arrange
        var sceneManager = new SceneManager();
        var inputManager = new InputManager(sceneManager);
        var userInput = "hitt goblin"; // typo in Aka

        // Act
        inputManager.ProcessInput(userInput);

        // Assert
        Assert.NotNull(inputManager.chosenAction);
        Assert.Equal("Punch", inputManager.chosenAction.Name);
    }
}
