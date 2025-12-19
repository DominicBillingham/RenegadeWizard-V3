namespace RenegadeWizardWasm.Core;

public abstract class GameAction
{
    
    // Metadata
    public string  Name { get; set; }
    public virtual List<string> Aka { get; set; } = new();
    public List<string> Names => Aka.Append(Name).ToList();
    
    // Entities involved
    public Entity Actor { get; set; }

    public List<Entity> Targets = new List<Entity>();
    
    // Effects
    public int? Damage { get; set; } 
    public int? Heal { get; set; }
    
    // Status Conditions m

}

public class Punch : GameAction
{
    public Punch()
    {
        Name = "Punch";
        Damage = 3;
    }
}

public class Heal : GameAction
{
    public Heal()
    {
        Name = "Heal";
        Heal = 3;
    }
}
