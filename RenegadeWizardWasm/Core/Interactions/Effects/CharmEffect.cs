using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Entities;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class CharmEffect : InteractionEffect
{
    public CharmEffect(ActionContext context, Entity actor, Entity target) : base(context)
    {
        Faction faction = actor.Faction;
        target.Faction = faction;
    }

}