using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core;

public class SceneManager
{
    public Entity Player => Entities.First(x => x.Controller == Controller.Player);
    public List<Entity> Entities { get; set; } = new();

    public SceneManager()
    {
        var player = new Player();
        var goblin = new Goblin();
        Entities.Add(player);
        Entities.Add(goblin);
    }
    
}
