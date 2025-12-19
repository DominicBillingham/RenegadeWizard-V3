namespace RenegadeWizardWasm.Core;

public class Entity
{
    
    public string  Name { get; set; }
    public List<string> Aka { get; set; } = new List<string>();

    public List<string> Names => Aka.Append(Name).ToList();
    public int Hitpoints { get; set; }
    
    public EntityType EntityType { get; set; }
    
    public Controller Controller { get; set; }

    public List<GameAction> Actions { get; set; } = new List<GameAction>();

}

public enum EntityType
{
    Creature,
    Object,
}

public enum Controller
{
    Player,
    Npc,
}