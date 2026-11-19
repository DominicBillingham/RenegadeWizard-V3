using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardTests.Actions;

public class PushActionTests
{
    [Fact]
    public void PushGoblinCrit()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());

        string userInput = "I push the goblin";
        manager.EnterInput(userInput);

        Assert.Contains(Tags.Unsteady, goblin.Tags);
    }

    [Fact]
    public void PushGoblinPass()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerPass());

        string userInput = "I push the goblin";
        manager.EnterInput(userInput);

        Assert.Contains(Tags.Unsteady, goblin.Tags);
    }

    [Fact]
    public void PushGoblinFail()
    {
        var goblin = Test.GetGoblin();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerFail());

        string userInput = "I push the goblin";
        manager.EnterInput(userInput);

        Assert.Equal(2, player.Stress);
    }

    [Fact]
    public void PushGoblinIntoSpikePitCrit()
    {
        var goblin = Test.GetGoblin();
        var spikePit = Test.GetSpikePit();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, spikePit, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerCrit());

        string userInput = "I push the goblin into the SpikePit";
        manager.EnterInput(userInput);

        Assert.Equal(2, goblin.Wounds);
    }

    [Fact]
    public void PushGoblinIntoSpikePitPass()
    {
        var goblin = Test.GetGoblin();
        var spikePit = Test.GetSpikePit();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, spikePit, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerPass());

        string userInput = "I push the goblin into the SpikePit";
        manager.EnterInput(userInput);

        Assert.Contains(Tags.Unsteady, goblin.Tags);
    }

    [Fact]
    public void PushGoblinIntoSpikePitFail()
    {
        var goblin = Test.GetGoblin();
        var spikePit = Test.GetSpikePit();
        var player = Test.GetPlayer();
        var scene = new SceneManager { Entities = new List<Entity> { goblin, spikePit, player } };
        var inputManager = new InputManager(scene);
        var manager = new GameManager(scene, inputManager, new DiceRollerFail());

        string userInput = "I push the goblin into the SpikePit";
        manager.EnterInput(userInput);

        Assert.Equal(2, player.Stress);
    }
}
