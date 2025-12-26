using System.ComponentModel.DataAnnotations;
using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core;

public abstract class GameAction()
{
    
    // Metadata
    public string Name { get; set; }
    public List<string> Aka { get; set; } = new();
    public List<string> Names => Aka.Append(Name).ToList();
    public TargetType TargetType { get; set; }
    
    // This ONLY describes the effect, NOT the target(s) as this is resolved by Interaction.cs
    
    public bool UsesItem { get; set; } = false;
    public abstract string Perform(Entity actor, Entity target, Entity? item = null);
}


