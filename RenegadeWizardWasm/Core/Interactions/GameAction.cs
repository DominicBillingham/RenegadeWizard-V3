namespace RenegadeWizardWasm.Core.Interactions;

public abstract class GameAction()
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> Aka { get; set; } = new();
    public List<string> Names => Aka.Append(Name).ToList();
    public string TargetHelpText { get; init; }
    public abstract bool TryGetTargets(Interaction context);
    public abstract void StackEffects(Interaction context);
}