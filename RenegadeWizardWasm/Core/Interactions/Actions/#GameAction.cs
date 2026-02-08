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
        Intent = Intent.Attack;
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
            DamageEffect damage = new(context, context.Actor, target, 1);
            if (damage.DamageDealt > 0)
            {
                HealEffect heal = new(context, context.Actor, damage.DamageDealt);
            }
        }
    }
}

public class MarkForDeath : GameAction
{
    
    public MarkForDeath()
    {
        Name = "MarkForDeath";
        Description = "Leaves the target vulnerable to all damage.";
        TargetHelpText = "I use MarkForDeath on [name]s";
        ActionTags = ["Damage", "DeBuff"];
        Intent = Intent.Debuff;
    }
    
    public Entity target { get; set; }
    
    public override void GetTargetsFromContext(ActionContext context)
    {
        target = context.IntendedTargets[0];

    }
    
    public override void Perform(ActionContext context)
    {
        Tag markedForDeath = new Vulnerable(Duration.Round);
        ApplyStatusEffect applyStatusEffect = new(context, target, markedForDeath);
    }
}





