using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.UserInterface;

namespace RenegadeWizardTests;

public class RoundTests
{
    [Fact]
    public void AttackCrit()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player } };
        
        var inputManager = new InputManager(scene);
        string userInput = "I attack glorb";
        
        Assert.Equal(1, glorb.Wounds);
    }
    
    [Fact]
    public void AttackSuccess()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player } };
        
        var inputManager = new InputManager(scene);
        string userInput = "I attack glorb";
        
        Assert.Contains(Tags.Stunned, glorb.Tags);
        Assert.Equal(0, glorb.Wounds);
    }
    
    [Fact]
    public void AttackFail()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player } };
        
        var inputManager = new InputManager(scene);
        string userInput = "I attack glorb";
        
        Assert.Equal(1, player.Stress);
        Assert.Equal(0, glorb.Wounds);
    }
    
    [Fact]
    public void AttackSpiky()
    {
        var spiky = Test.GetSpikyMob();
        var player = Test.GetPlayer();
        var scene = new SceneManager() { Entities = new List<Entity>() { spiky, player } };
        
        var inputManager = new InputManager(scene);
        string userInput = "I attack spiky";
        
        Assert.Equal(1, spiky.Wounds);
        Assert.Equal(1, player.Wounds);
    }
    
    [Fact]
    public void ThrowTable()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player } };
        
        var inputManager = new InputManager(scene);
        string userInput = "I throw the table at glorb";
        
        Assert.Equal(1, glorb.Wounds);
    }

    [Fact]
    public void ThrowTableBlindMiss()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player } };
        
        var inputManager = new InputManager(scene);
        string userInput = "I throw the table at glorb";
        
        Assert.Equal(0, glorb.Wounds);
    }

    [Fact]
    public void ThrowTableBlindHit()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var table = Test.GetTable();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player, table } };
        
        var inputManager = new InputManager(scene);
        string userInput = "I throw the table at glorb";
        
        Assert.Equal(1, glorb.Wounds);
        Assert.True(table.IsDestroyed);
    }
    
    
    

}