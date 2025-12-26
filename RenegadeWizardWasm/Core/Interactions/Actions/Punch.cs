using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public class Punch : GameAction
{
    public Punch()
    {
        Name = "Punch";
        Aka = ["Hit", "Slap", "Whack"];
        UsesItem = false;
        TargetType = TargetType.Chosen;
    }

    public override string Perform(Entity actor, Entity target, Entity? item = null)
    {
        target.Hitpoints -= 3;
        return $"{actor.Name} punches {target.Name} for 3hp.";
    }
}
