using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Interactions.Effects;

public class NoiseEffect : BaseEffect
{
    public override void Execute()
    {
        foreach (var entity in Context.AllEntities)
        {
            if (entity.Tags.Contains(Tags.LoudNoiseFear))
            {
                entity.IsDefeated = true;
            }
        }
    }
}