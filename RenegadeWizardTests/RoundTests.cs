using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

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
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());
        
        string userInput = "I attack glorb";
        manager.EnterInput(userInput);
        
        Assert.Equal(1, glorb.Wounds);
    }
    
    [Fact]
    public void AttackPass()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerPass());
        
        string userInput = "I attack glorb";
        manager.EnterInput(userInput);
        
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
        var manager = new GameManager(scene, inputManager, new DiceRollerFail());
        
        string userInput = "I attack glorb";
        manager.EnterInput(userInput);
        
        Assert.Equal(1, player.Stress);
        Assert.Equal(0, glorb.Wounds);
    }
    
    [Fact]
    public void AttackCritSpiky()
    {
        var spiky = Test.GetSpikyMob();
        var player = Test.GetPlayer();
        var scene = new SceneManager() { Entities = new List<Entity>() { spiky, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());
        
        string userInput = "I attack spiky";
        manager.EnterInput(userInput);

        Assert.Equal(1, spiky.Wounds);
        Assert.Equal(1, player.Wounds);
    }
    
    [Fact]
    public void ThrowTable()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var table = Test.GetTable();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player, table } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());
        
        string userInput = "I throw the table at glorb";
        manager.EnterInput(userInput);
        
        Assert.Equal(1, glorb.Wounds);
    }

    [Fact]
    public void ThrowTableBlindMiss()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var table = Test.GetTable();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player, table } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());
        
        string userInput = "I throw the table at glorb";
        manager.EnterInput(userInput);
        
        Assert.Equal(0, glorb.Wounds);
        Assert.True(table.IsDefeated);
    }

    [Fact]
    public void ThrowTableBlindHit()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var table = Test.GetTable();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player, table } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());
        
        string userInput = "I throw the table at glorb";
        manager.EnterInput(userInput);
        
        Assert.Equal(1, glorb.Wounds);
        Assert.True(table.IsDefeated);
    }
    
    [Fact]
    public void ThrowTableSurprised()
    {
        var glorb = Test.GetGlorb();
        var player = Test.GetPlayer();
        var table = Test.GetTable();
        var scene = new SceneManager() { Entities = new List<Entity>() { glorb, player, table } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());
        
        string userInput = "I throw the table at glorb";
        manager.EnterInput(userInput);
        
        Assert.Equal(2, glorb.Wounds);
        Assert.True(table.IsDefeated);
    }
}