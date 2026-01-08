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


        if (!GameAction.TryGetTargets(this))
        {
            AllowRetry = true;
            return;
        }

        GameAction.StackEffects(this);
    }

    // Results of the interaction.
    public List<Entity> ActualTargets { get; set; } = [];
    public List<InteractionEffect> Effects { get; set; } = [];
    public bool AllowRetry { get; set; } = false;
    public string Result { get; set; } = "";

    
    public string ApplyEffects()
    {
        foreach (InteractionEffect effect in Effects)
        {
            effect.Apply();
            Result += effect.Text;
        }

        return Result;
    }
}

