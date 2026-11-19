using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardTests.Actions;

public class AttackActionTests
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
        
        string userInput = "I attack spikymob";
        manager.EnterInput(userInput);

        Assert.Equal(1, spiky.Wounds);
        Assert.Equal(1, player.Wounds);
    }

    [Fact]
    public void AttackGoblinCrit()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());

        string userInput = "I attack the goblin";
        manager.EnterInput(userInput);

        Assert.Equal(1, goblin.Wounds);
        Assert.Contains(Tags.Stunned, goblin.Tags);
    }

    [Fact]
    public void AttackGoblinPass()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerPass());

        string userInput = "I attack the goblin";
        manager.EnterInput(userInput);

        Assert.Contains(Tags.Stunned, goblin.Tags);
        Assert.Equal(0, goblin.Wounds);
    }

    [Fact]
    public void AttackGoblinFail()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerFail());

        string userInput = "I attack the goblin";
        manager.EnterInput(userInput);

        Assert.Equal(1, player.Stress);
        Assert.Equal(0, goblin.Wounds);
    }

    [Fact]
    public void AttackGoblinUnsteadyCrit()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        player.Tags.Add(Tags.Unsteady);
        var table = Test.GetTable();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player, table } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());

        string userInput = "I attack the goblin";
        manager.EnterInput(userInput);

        Assert.Equal(1, goblin.Wounds);
    }

    [Fact]
    public void AttackGoblinUnsteadyPass()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        player.Tags.Add(Tags.Unsteady);
        var table = Test.GetTable();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player, table } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerPass());

        string userInput = "I attack the goblin";
        manager.EnterInput(userInput);

        Assert.Equal(0, goblin.Wounds);
        Assert.Equal(1, table.Wounds);
    }

    [Fact]
    public void AttackGoblinUnsteadyFail()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        player.Tags.Add(Tags.Unsteady);
        var table = Test.GetTable();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player, table } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerFail());

        string userInput = "I attack the goblin";
        manager.EnterInput(userInput);

        Assert.Equal(1, goblin.Wounds);
        Assert.Equal(0, table.Wounds);
    }
}
