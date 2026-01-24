using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardWasm.Core.Interactions.Modifiers;

public class Attached : Modifier
{
    public Attached(int attachment)
    {
        Name = "Attached";
        AttachmentStrength = attachment;
    }
    public int AttachmentStrength { get; set; }
    public override void ModifyEffects(InteractionEffect effect)
    {
        if (effect is DetachEffect detachEffect)
        {
            detachEffect.AttachmentStrength += AttachmentStrength;
        }
    }
}


