namespace RenegadeWizardWasm.Core.Models;

public class Entity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool IsPlayer { get; set; } = false;
}