using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardTests.Actions;

public class ThrowActionTests
{
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

    [Fact]
    public void ThrowTableAtGoblinCrit()
    {
        var goblin = Test.GetGoblin();
        var table = Test.GetTable();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, table, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());

        string userInput = "I throw the table at the goblin";
        manager.EnterInput(userInput);

        Assert.True(table.IsDefeated);
        Assert.Equal(1, goblin.Wounds);
    }

    [Fact]
    public void ThrowTableAtGoblinPass()
    {
        var goblin = Test.GetGoblin();
        var table = Test.GetTable();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, table, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerPass());

        string userInput = "I throw the table at the goblin";
        manager.EnterInput(userInput);

        Assert.True(table.IsDefeated);
        Assert.Contains(Tags.Stunned, goblin.Tags);
    }

    [Fact]
    public void ThrowTableAtGoblinFail()
    {
        var goblin = Test.GetGoblin();
        var table = Test.GetTable();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, table, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerFail());

        string userInput = "I throw the table at the goblin";
        manager.EnterInput(userInput);

        Assert.Equal(1, player.Stress);
    }

    [Fact]
    public void ThrowGoblinAtTableCrit()
    {
        var goblin = Test.GetGoblin();
        var table = Test.GetTable();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, table, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());

        string userInput = "I throw the goblin at the table";
        manager.EnterInput(userInput);

        Assert.True(table.IsDefeated);
        Assert.Equal(1, goblin.Wounds);
    }

    [Fact]
    public void ThrowGoblinAtTablePass()
    {
        var goblin = Test.GetGoblin();
        var table = Test.GetTable();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, table, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerPass());

        string userInput = "I throw the goblin at the table";
        manager.EnterInput(userInput);

        Assert.True(table.IsDefeated);
        Assert.Contains(Tags.Stunned, goblin.Tags);
    }

    [Fact]
    public void ThrowGoblinAtTableFail()
    {
        var goblin = Test.GetGoblin();
        var table = Test.GetTable();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, table, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerFail());

        string userInput = "I throw the goblin at the table";
        manager.EnterInput(userInput);

        Assert.Equal(1, player.Stress);
    }
}
