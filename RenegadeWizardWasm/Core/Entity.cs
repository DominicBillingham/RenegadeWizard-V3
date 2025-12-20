using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core;

public class Entity
{
    
    // All modifications to any entity shoud go through their setter, in case if they have something like ignore fire damage.
    // Likewise, you should only get the value using the getter in case if they have a modifier like something boosting their strentth.
    // Ideally, all fields should be private to prevent mistakes from being made.
    
    public string  Name { get; set; }
    public List<string> Aka { get; set; } = new List<string>();
    public List<string> Names => Aka.Append(Name).ToList();
    public int Hitpoints { get; set; }
    public Controller Controller { get; set; }
    public List<GameAction> Actions { get; set; } = new List<GameAction>();
    
    
    // Skills
    public int? Strength { get; set; } = 10;
    public int? Dexterity { get; set; } = 10;
    public int? Constitution { get; set; } = 10;
    public int? Intelligence { get; set; } = 10;
    public int? Wisdom { get; set; } = 10;
    public int? Charisma { get; set; } = 10;
    
    // Senses
    public int? Smell { get; set; }
    public int? Taste { get; set; }
    
    // Tool usage
    public int? Weight { get; set; } = 3;
    public int? Sharpness { get; set; }

}



public class Player : Entity
{
    public Player()
    {
        Name = "Player";
        Controller = Controller.Player;
        Hitpoints = 10;
        Actions.Add(new Punch());
        Actions.Add(new Heal());
    }
}

public class Goblin : Entity
{
    public Goblin()
    {
        Name = "Goblin";
        Controller = Controller.Npc;
        Hitpoints = 5;
        Actions.Add(new Punch());
    }
}

public class HealingPotion : Entity
{
    public HealingPotion()
    {
        Name = "Healing Potion";
        Hitpoints = 10;
    }
}