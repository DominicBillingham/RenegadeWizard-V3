using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Entities;

namespace RenegadeWizardWasm.Core.Interactions.Tags;

public class Attached : Tag
{
    public Entity? AttachedTo { get; set; }
    public int AttachmentStrength { get; set; }
    
    public Attached(Duration duration, int attachmentStrength, Entity? attachedTo = null) : base(duration)
    {
        Name = "Attached";
        AttachedTo = attachedTo;
        AttachmentStrength = attachmentStrength;
    }
}
