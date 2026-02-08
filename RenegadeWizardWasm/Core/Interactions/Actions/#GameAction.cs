using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions;
using RenegadeWizardWasm.Core.Interactions.Actions;
using RenegadeWizardWasm.Core.Interactions.Effects;
using RenegadeWizardWasm.Core.Interactions.Entities;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public abstract class GameAction()
{
    
    // Action information
    public string Name { get; set; }
    public string Description { get; set; }
    public Intent Intent { get; set; }
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




public class Reaper : GameAction
{
    
    public Reaper()
    {
        Name = "SoulReaper";
        Description = "Drains the souls of every living creature for your own gain.";
        TargetHelpText = "I use SoulReaper";
        ActionTags = ["Damage", "AoE"];
    }
    
    List<Entity> livingCreatures = [];
    
    public override void GetTargetsFromContext(ActionContext context)
    {
        livingCreatures = context.AllEntities.Where(ent => ent.Tags.Any(tag => tag is Organic)).ToList();
    }
    
    public override void Perform(ActionContext context)
    {
        
        foreach (Entity target in livingCreatures)
        {
        }
    }
}

    




public class Summon : GameAction
{
    public Summon()
    {
        Name = "Summon";
        Description = "Conjure a portal, reach into it's depths and pull *something* out...";
        Aka = ["Conjure"];
        TargetHelpText = "I summon [name]";
        ActionTags = ["Summoning"];
    }

    public override void GetTargetsFromContext(ActionContext context)
    {
    }

    public override void Perform(ActionContext context)
    {



    }
}
