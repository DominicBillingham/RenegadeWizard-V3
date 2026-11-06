using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Models;

public class ActionIdentity
{
    public required List<string> Names { get; set; }
    public required ActionId ActionId { get; set; }
}