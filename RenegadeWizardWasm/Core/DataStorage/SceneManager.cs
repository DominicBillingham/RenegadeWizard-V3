using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core;

public class SceneManager
{
    public List<Entity> Entities { get; set; } = new();
    public Entity Player => Entities.First(x => x.Controller == Controller.Player);
    public List<Entity> Npcs => Entities.Where(x => x.Controller == Controller.Npc).ToList();
    public List<Entity> Objects => Entities.Where(x => x.Controller == Controller.Object).ToList();
    
    public SceneManager()
    {
        var player = new Player();
        var goblin = new Goblin();
        var goblin2 = new Goblin
        {
            Name = "John"
        };
        var ironGolem = new IronGolem();
        var table = new Table();
        var chair = new Chair();
        Entities.Add(player);
        Entities.Add(goblin); 
        Entities.Add(goblin2);
        Entities.Add(ironGolem);
        Entities.Add(table);
        Entities.Add(chair);
    }
    public List<string> GetSceneDescription()
    {
        List<string> sceneLines = new List<string>();
        foreach (Entity entity in Entities)
        {
            //sceneLines.Add($"[{entity.Name}] #rd {entity.Hitpoints}hp. # Some text afterwards. ");
        }
        return sceneLines;
    }
    
}
