using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core;

public class SceneManager
{
    public Entity Player => Entities.First(x => x.Controller == Controller.Player);
    public List<Entity> Npcs => Entities.Where(x => x.Controller == Controller.Npc).ToList();

    public List<Entity> Entities { get; set; } = new();

    public SceneManager()
    {
        var player = new Player();
        var goblin = new Goblin();
        Entities.Add(player);
        Entities.Add(goblin);
    }
    
    public List<string> GetSceneDescription()
    {
        List<string> sceneLines = new List<string>();
        foreach (Entity entity in Entities)
        {
            sceneLines.Add($"[{entity.Name}] {entity.Hitpoints}hp.");
        }
        return sceneLines;
    }
    
}
