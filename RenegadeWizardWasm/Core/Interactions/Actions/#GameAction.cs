using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions;

public abstract class GameAction()
{
    
    // Action information
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; } = "circle";
    public List<string> Aka { get; set; } = new();
    public List<string> Names => Aka.Append(Name).ToList();
    public List<string> ActionTags { get; set; } = [];

    
    // Target Methods
    public string TargetHelpText { get; init; }
    
    public abstract void GetTargetsFromContext(ActionContext context);

    // Allows the NPCs to know how to actually use actions rather than just assuming the player.
    public virtual List<Entity> NpcGetTargets(IReadOnlyCollection<Entity> possibleTargets)
    {
        List<Entity> targets = new();
        Entity? player = possibleTargets.FirstOrDefault(x => x.Controller == Controller.Player);
        if (player != null)
        {
            targets.Add(player);
        }
        return targets;
    }
    
    public abstract void Perform(ActionContext context);
}