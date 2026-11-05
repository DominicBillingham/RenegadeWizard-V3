using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Models;

public class Identity
{
    public required List<string> Names { get; set; }
    public ActionId? ActionId { get; set; }
    public int? EntityId { get; set; }
}