namespace RenegadeWizardWasm.Core;

// Essentially, the interaction object is a giant command object (made from smaller command objects, called effects!)
// Effects can be ANYTHING, they are the smallest piece of the game (like taking damage, being moved, etc).
// An effect is one actor, one entity, and the modifers that change the results of the effect.
// Finally, the effects can then be applied after everything has settled down.
public class Interaction(
    Entity? actor,
    GameAction? gameAction,
    IReadOnlyCollection<Entity> allEntities,
    List<Entity> desiredTargets)
{
    // This data should never be modified, because then the command pattern would be broken.
    public readonly Entity? Actor = actor;
    public readonly GameAction? GameAction = gameAction;
    public readonly IReadOnlyCollection<Entity> AllEntities = allEntities;
    public readonly List<Entity> DesiredTargets = desiredTargets;

    // Takes the readonly values, and uses them to calculate WHAT would happen.
    public void GetEffects()
    {
        if (Actor is null)
        {
            Result = "No actor selected.";
            AllowRetry = true;
            return;
        }

        if (GameAction is null)
        {
            Result = "No action selected.";
            AllowRetry = true;
            return;
        }

        GameAction.GetTargets(this);

        if (ActualTargets.Count == 0)
        {
            AllowRetry = true;
            return;
        }

        GameAction.GetEffects(this);
    }

    // Results of the interaction.
    public List<Entity> ActualTargets { get; set; } = [];
    public List<InteractionEffects> Effects { get; set; } = [];
    public bool AllowRetry { get; set; } = false;
    public string Result { get; set; } = "";

    public string ApplyEffects()
    {
        foreach (InteractionEffects effect in Effects)
        {
            effect.Apply(effect.Target);
            Result += effect.Text;
        }

        return Result;
    }
}

public abstract class InteractionEffects()
{
    public Entity Target { get; set; }
    public Entity Actor { get; set; }
    public List<Mod> Modifiers { get; set; } = [];
    public string Text { get; set; } = "";
    public abstract void Apply(Entity target);
}

public class DamageEffects() : InteractionEffects()
{
    public int Damage { get; set; }

    public override void Apply(Entity target)
    {
        foreach (var mod in Modifiers)
        {
            mod.ModifyEffect(this);
        }

        Text += $"{target.Name} takes {Damage} damage";

        if (Modifiers.Any())
        {
            Text += $", modifed by [{string.Join(", ", Modifiers.Select(mod => mod.Name))}].";
        }

        target.Hitpoints -= Damage;
    }
}