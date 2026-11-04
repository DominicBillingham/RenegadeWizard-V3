using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardTests;

public class InputManagerTests
{
    
    [Fact]
    public void SelectAction()
    {
        var scene = Test.GetBasicScene();
        var inputManager = new InputManager(scene);        

        string userInput = "I kick the monster right up the arse";
        inputManager.ProcessInput(userInput);
        
        Assert.Equal(ActionNames.Kick, inputManager.ChosenAction);
    }
        
    [Fact]
    public void SelectActionInOrder()
    {
        var scene = Test.GetBasicScene();
        var inputManager = new InputManager(scene);     
        
        string userInput = "I kick the monster right up the arse, then violently punch it.";
        inputManager.ProcessInput(userInput);
        
        Assert.Equal(ActionNames.Kick, inputManager.ChosenAction);
    }
    
    [Fact]
    public void SelectMisspeltAction()
    {
        var scene = Test.GetBasicScene();
        var inputManager = new InputManager(scene);    
        
        string userInput = "I kik the monster";
        inputManager.ProcessInput(userInput);
        
        Assert.Equal(ActionNames.Kick, inputManager.ChosenAction);
    }
    
    [Fact]
    public void SelectTargets()
    {
        var scene = Test.GetBasicScene();
        var inputManager = new InputManager(scene);      
       
        string userInput = "I kick GLORB";
        inputManager.ProcessInput(userInput);
    
        Assert.Single(inputManager.ChosenTargets);
        Assert.Equal("Glorb", inputManager.ChosenTargets[0].Name);
    }
    
    [Fact]
    public void SelectTargetsInOrder()
    {
        var scene = Test.GetBasicScene();
        var inputManager = new InputManager(scene);      
        
        string userInput = "I punch GLORB, then TUBA";
        inputManager.ProcessInput(userInput);
    
        Assert.Equal(ActionNames.Punch, inputManager.ChosenAction);
        Assert.Equal("Glorb", inputManager.ChosenTargets[0].Name);
        Assert.Equal("Tuba", inputManager.ChosenTargets[1].Name);
    }
    
    [Fact]
    public void SelectMisspeltTarget()
    {
        var scene = Test.GetBasicScene();
        var inputManager = new InputManager(scene);      
        
        string userInput = "I kick GLOB";
        inputManager.ProcessInput(userInput);
    
        Assert.Single(inputManager.ChosenTargets);
        Assert.Equal("Glorb", inputManager.ChosenTargets[0].Name);
    }
}
