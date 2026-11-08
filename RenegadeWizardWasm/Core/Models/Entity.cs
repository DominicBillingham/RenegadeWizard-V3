using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Models;

public class Entity
{
    // Not Required
    public bool IsPlayer { get; set; } = false;
    public List<Tags> Tags { get; set; } = new List<Tags>();
    public bool IsDefeated { get; set; } = false;

    // Required
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int MaxWounds { get; set; }
    public required int MaxStress { get; set; }
    public int Wounds { get; set; } = 0;
    public int Stress { get; set; } = 0;
    public required PlayerRelationship Relationship { get; set; }
    public required Size Size { get; set; }
    
}