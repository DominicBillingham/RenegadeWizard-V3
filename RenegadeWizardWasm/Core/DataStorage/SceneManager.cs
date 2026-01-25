
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Entities;

namespace RenegadeWizardWasm.Core.DataStorage;

public class SceneManager
{
    private List<Entity> _entities { get; set; } = new();
    public IReadOnlyCollection<Entity> Entities => _entities;
    public Entity Player => Entities.First(x => x.Controller == Controller.Player);
    public List<Entity> Npcs => Entities.Where(x => x.Controller == Controller.Npc).ToList();
    public List<Entity> Objects => Entities.Where(x => x.Controller == Controller.Object).ToList();
    
    public SceneManager()
    {
        _entities.Add(new Player());
        Level1();
    }

    public string Level1()
    {
        var tempPlayer = Player;
        _entities.Clear();
        _entities.Add(tempPlayer);
        _entities.Add(new Door()); 
        return "Level 1 loaded";
    }
    
    public string Level2()
    {
        var tempPlayer = Player;
        _entities.Clear();
        _entities.Add(tempPlayer);
        _entities.Add(new Goose()); 
        return "Level 2 loaded";
    }
    
    public string Level3()
    {
        var tempPlayer = Player;
        _entities.Clear();
        _entities.Add(tempPlayer);
        _entities.Add(new Goblin()); 
        return "Level 3 loaded";
    }
    
    public void RemoveDestroyedEntities()
    {
        _entities.RemoveAll(x => x.Hitpoints <= 0);
    }
}
