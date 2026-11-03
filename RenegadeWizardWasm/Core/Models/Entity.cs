using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Models;

public class Entity
{
    // Not Required
    public bool IsPlayer { get; set; } = false;
    public List<Tags> Tags { get; set; } = new List<Tags>();

    // Required
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int MaxWounds { get; set; }
    public int Wounds { get; set; } = 0;
    public required PlayerRelationship Relationship { get; set; }
    
}