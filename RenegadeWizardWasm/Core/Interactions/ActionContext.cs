namespace RenegadeWizardWasm.Core.Interactions;

// Every action is broken down into effects. Each effect is the smallest possible operation, such as healing, knockback, etc.
// This means actions essentially orchestrate effects, such as a lift effect succeeding before dealing damage for throw.
// Every effect has a core, for example, a damage effect the core is actually dealing damage.
// Every effect is then modified by boosters (from the actor), modifiers (from the target) and a potential replacer.
// Boosters improve the effect, modifiers add / modify the effect; replaces change the effects result.
// For example, the damage effect has a core that deals damage, booster may double the damage, modifer may reduce it by -5, replace may reflect the damage instead.

public class ActionContext(
    Entity? actor,
    GameAction? gameAction,
    IReadOnlyCollection<Entity> allEntities,
    List<Entity> desiredTargets)
{
    public readonly Entity? Actor = actor;
    public readonly GameAction? GameAction = gameAction;
    public readonly IReadOnlyCollection<Entity> AllEntities = allEntities;
    public readonly List<Entity> DesiredTargets = desiredTargets;

    public string Resolve()
    {
        if (Actor is null)
        {
            Result = "No actor selected.";
            AllowRetry = true;
            return Result;
        }

        if (GameAction is null)
        {
            Result = "No action selected.";
            AllowRetry = true;
            return Result;
        }

        if (!GameAction.TryGetTargets(this))
        {
            AllowRetry = true;
            return Result;
        }

        GameAction.Perform(this);
        
        foreach (var effect in CombatLog)
        {
            if (effect.HideResult) continue;
            Result += effect.Result;
        }

        return Result;
    }

    public List<Entity> ActualTargets { get; set; } = [];
    public List<InteractionEffect> CombatLog { get; set; } = [];
    public bool AllowRetry { get; set; } = false;
    public string Result { get; set; } = "";
    
}

