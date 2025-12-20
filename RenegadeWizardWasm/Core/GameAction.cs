using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core;

public abstract class GameAction()
{
    
    // Metadata
    public string Name { get; set; }
    public virtual List<string> Aka { get; set; } = new();
    public List<string> Names => Aka.Append(Name).ToList();
    public TargetType TargetType { get; set; } = TargetType.Self;
    
    // This ONLY describes the effect, NOT the target(s) as this is resolved by Interaction.cs
    public abstract string Effect(Entity actor, Entity target, Entity? item = null);
}


public class Throw : GameAction
{

    public Throw() 
    {
        Name = "Throw";
    }

    public override string Effect(Entity actor, Entity target , Entity? item = null)
    {
        if (item == null) 
            return "Well you managed to some how throw [NULL] so uh, fuck you.";

        if (item.Weight is { } weight && actor.Strength > weight)
        {
            target.Hitpoints -= weight;
            return $"{actor.Name} throws {item.Name} at {target.Name} for {weight}hp.";
        }
        else
        {
            return $"{actor.Name} fails to lift {item.Name}!";
        }
    }
}

