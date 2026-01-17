namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class CharmEffect : InteractionEffect
{
    protected override void Core()
    {
        Target.Faction = Actor.Faction;
        Result = $"{Actor.Name} charms {Target.Name}.";
    }
}
