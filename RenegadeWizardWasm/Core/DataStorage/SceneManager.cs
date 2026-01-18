
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Entities;

namespace RenegadeWizardWasm.Core.DataStorage;

public class SceneManager
{
    private List<Entity> _entities = new();
    public IReadOnlyList<Entity> Entities => _entities;
    public Entity Player => Entities.First(x => x.Controller == Controller.Player);
    public List<Entity> Npcs => Entities.Where(x => x.Controller == Controller.Npc).ToList();
    public List<Entity> Objects => Entities.Where(x => x.Controller == Controller.Object).ToList();
    
    public SceneManager()
    {
        _entities.Add(new Player());
        
        _entities.Add(new Goblin()); 
        _entities.Add(new Goblin()
        {
            Name = "Goblin Lord Adam",
            Description = "A goblin lord, but still just as ugly!",
            Controller = Controller.Npc,
        }); 
        
        _entities.Add(new IronGolem());
        
        _entities.Add(new Door());
        _entities.Add(new Chair());
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
