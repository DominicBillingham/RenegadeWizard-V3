
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Entities;
using RenegadeWizardWasm.Core.Interactions.Tags;

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
        
        _entities.Add(new Goblin()
        {
            Name = "EternalAdam",
            Description = "A wise old gremlin with a long beard and a staff.",
            Tags = [new Immortal(Duration.Permanent)]
        });
        
        _entities.Add(new Goblin()
        {
            Name = "GiantGarry",
            Description = "A giant goblin with a huge head.",
            Tags = [new Huge(Duration.Permanent), new Tenacious(Duration.Permanent)]
        });
        
        _entities.Add(new Goblin()
        {
            Name = "PatheticPenny",
            Description = "She's trying - probably harder than you.",
            Tags = [new Vulnerable(Duration.Permanent), new  Terrified(Duration.Permanent)]
        });
        
        _entities.Add(new Window()); 
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
