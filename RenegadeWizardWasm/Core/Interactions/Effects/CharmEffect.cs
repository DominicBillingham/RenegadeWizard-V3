using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class CharmEffect : InteractionEffect
{
    public CharmEffect(ActionContext context) : base(context)
    {
        Faction faction = context.Actor.Faction;
        context.ActualTargets.ForEach(target => target.Faction = faction);
    }

}