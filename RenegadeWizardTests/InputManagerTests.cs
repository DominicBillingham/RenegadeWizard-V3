using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.UserInterface;
using Xunit;

namespace RenegadeWizardTests;

public class InputManagerTests
{

    private SceneManager getScene()
    {
        var scene = new SceneManager()
        {
            Entities = new List<Entity>()
            {
                new Entity { Name = "Glorb", Description = "The menance" },
                new Entity { Name = "Grendal", Description = "The terror" },
                new Entity { Name = "Tuba", Description = "The horror" },
            }
        };
        return scene;
    }
    
    [Fact]
    public void SelectAction()
    {
        var inputManager = new InputManager(getScene());
        string userInput = "I kick the monster right up the arse";
        inputManager.ProcessInput(userInput);
        
        Assert.Equal(ActionNames.Kick, inputManager.ChosenAction);
    }
        
    [Fact]
    public void SelectActionInOrder()
    {
        var inputManager = new InputManager(getScene());
        string userInput = "I kick the monster right up the arse, then violently punch it.";
        inputManager.ProcessInput(userInput);
        
        Assert.Equal(ActionNames.Kick, inputManager.ChosenAction);
    }
    
    
    [Fact]
    public void SelectMisspeltAction()
    {
        var inputManager = new InputManager(getScene());
        string userInput = "I kik the monster";
        inputManager.ProcessInput(userInput);
        
        Assert.Equal(ActionNames.Kick, inputManager.ChosenAction);
    }
    
    [Fact]
    public void SelectTargets()
    {
        var inputManager = new InputManager(getScene());
        string userInput = "I kick GLORB";
        inputManager.ProcessInput(userInput);
    
        Assert.Single(inputManager.ChosenTargets);
        Assert.Equal("Glorb", inputManager.ChosenTargets[0].Name);
    }
    
    [Fact]
    public void SelectTargetsInOrder()
    {
        var inputManager = new InputManager(getScene());
        string userInput = "I punch GLORB, then TUBA";
        inputManager.ProcessInput(userInput);
    
        Assert.Equal(ActionNames.Punch, inputManager.ChosenAction);
        Assert.Equal("Glorb", inputManager.ChosenTargets[0].Name);
        Assert.Equal("Tuba", inputManager.ChosenTargets[1].Name);
    }
    
    
    [Fact]
    public void SelectMisspeltTarget()
    {
        var inputManager = new InputManager(getScene());
        string userInput = "I kick GLOB";
        inputManager.ProcessInput(userInput);
    
        Assert.Single(inputManager.ChosenTargets);
        Assert.Equal("Glorb", inputManager.ChosenTargets[0].Name);
    }

    
}
