
namespace RenegadeWizardWasm.Core;

public class SceneManager
{
    private List<Entity> _entities = new();
    public IReadOnlyList<Entity> Entities => _entities;
    public Entity Player => Entities.First(x => x.Controller == Controller.Player);
    public List<Entity> Npcs => Entities.Where(x => x.Controller == Controller.Npc).ToList();
    public List<Entity> Objects => Entities.Where(x => x.Controller == Controller.Object).ToList();
    
    public SceneManager()
    {
        var player = new Player();
        var goblin = new Goblin();
        var goblin2 = new Goblin
        {
            Hitpoints = 54,
            Name = "Adam",
            Description = "King of the goblins"
        };
        var ironGolem = new IronGolem();
        var table = new Table();
        var chair = new Chair();
        _entities.Add(player);
        _entities.Add(goblin); 
        _entities.Add(goblin2);
        _entities.Add(ironGolem);
        _entities.Add(table);
        _entities.Add(chair);
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
