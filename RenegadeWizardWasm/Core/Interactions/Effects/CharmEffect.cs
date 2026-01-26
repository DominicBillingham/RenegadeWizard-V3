using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class CharmEffect : InteractionEffect
{
    public CharmEffect(ActionContext context, Entity actor, Entity target) : base(context)
    {
        Faction faction = actor.Faction;
        target.Faction = faction;
    }

}