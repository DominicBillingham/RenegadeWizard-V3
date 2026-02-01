using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;

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
    List<Entity> intendedTargets
    )
{
    public readonly Entity? Actor = actor;
    public readonly GameAction? GameAction = gameAction;
    public readonly IReadOnlyCollection<Entity> AllEntities = allEntities;
    public readonly List<Entity> IntendedTargets = intendedTargets;

    public string Resolve()
    {
        if (Actor is null)
        {
            Result = "No actor selected.";
            AllowRetry = true;
            return Result;
        }

        if (Actor.Hitpoints <= 0)
        {
            Result = $"{Actor.Name} died before they could do anything!";
            return Result;
        }

        if (GameAction is null)
        {
            Result = "No action selected.";
            AllowRetry = true;
            return Result;
        }
        
        // Allows the target methods to be unsafe
        try
        {
            GameAction.GetTargetsFromContext(this);
        }
        catch
        {
            AllowRetry = true;
            if (Actor.Controller == Controller.Npc)
            {
                Result = $"{Actor.Name} faffs about confused";
            }

            if (Actor.Controller == Controller.Player)
            {
                Result = $"To use {GameAction.Name}: {GameAction.TargetHelpText}";
                return Result;
            }
        }
    

        GameAction.Perform(this);
        
        foreach (var effect in CombatLog)
        {
            if (effect.HideResult) continue;
            Result += effect.Result;
        }

        return Result;
    }

    public List<InteractionEffect> CombatLog { get; set; } = [];
    public bool AllowRetry { get; set; } = false;
    public string Result { get; set; } = "";
    
}

