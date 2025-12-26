using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Throw : GameAction
{

    public Throw() 
    {
        Name = "Throw";
        Aka = ["Hurl", "Yeet", "Toss"];
        UsesItem = true;
        TargetType = TargetType.Chosen;
    }

    public override string Perform(Entity actor, Entity target , Entity? item = null)
    {
        if (item == null) 
            return "Well you managed to some how throw [NULL] so uh, fuck you.";

        if (item.Weight is { } weight && actor.Strength > weight)
        {
            return $"{actor.Name} throws {item.Name} at {target.Name}. {target.ApplyDamage(weight)}";
        }
        else
        {
            return $"{actor.Name} fails to lift {item.Name}!";
        }
    }
}
