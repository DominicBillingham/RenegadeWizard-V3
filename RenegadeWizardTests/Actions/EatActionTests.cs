using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardTests.Actions;

public class EatActionTests
{
    [Fact]
    public void EatGoblinCrit()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        player.Wounds = 1;
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());

        string userInput = "I eat the goblin";
        manager.EnterInput(userInput);

        Assert.True(goblin.IsDefeated);
        Assert.Equal(0, player.Wounds);
    }

    [Fact]
    public void EatGoblinPass()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerPass());

        string userInput = "I eat the goblin";
        manager.EnterInput(userInput);

        Assert.Equal(1, goblin.Wounds);
    }

    [Fact]
    public void EatGoblinFail()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerFail());

        string userInput = "I eat the goblin";
        manager.EnterInput(userInput);

        Assert.Equal(1, player.Wounds);
        Assert.Equal(0, goblin.Wounds);
    }

    [Fact]
    public void EatTableCrit()
    {
        var table = Test.GetTable();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { table, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());

        string userInput = "I eat the table";
        manager.EnterInput(userInput);

        Assert.True(table.IsDefeated);
    }

    [Fact]
    public void EatTablePass()
    {
        var table = Test.GetTable();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { table, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerPass());

        string userInput = "I eat the table";
        manager.EnterInput(userInput);

        Assert.True(player.Stress > 0);
    }

    [Fact]
    public void EatTableFail()
    {
        var table = Test.GetTable();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { table, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerFail());

        string userInput = "I eat the table";
        manager.EnterInput(userInput);

        Assert.Equal(1, player.Wounds);
    }
}
