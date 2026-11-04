using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardTests;

public class IntergrationTests
{
    [Fact]
    public void Punch()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player } };
        
        var inputManager = new InputManager(scene);
        string userInput = "I attack glorb";
        
        Assert.Equal(1, glorb.Wounds);
    }

}