namespace RenegadeWizardWasm.Core;


// Essentially, the interaction object is a command object (made from smaller command objects, called events!)
// Events can be ANYTHING, they are the smallest piece of the game (like taking damage, being moved, etc).
// The interaction object gets the action, and slowly builds up a list of events that will happen.
public class Interaction(Entity? actor, GameAction? gameAction, IReadOnlyCollection<Entity> allEntities, List<Entity> desiredTargets)
{
    // This data should never be modified, because then the command pattern would be broken.
    public readonly Entity? Actor = actor;
    public readonly GameAction? GameAction = gameAction;
    public readonly IReadOnlyCollection<Entity> AllEntities = allEntities;
    public readonly List<Entity> DesiredTargets = desiredTargets;

    // Takes the readonly values, and uses them to calculate WHAT would happen.
    public void CalculateResult()
    {

        if (Actor is null)
        {
            Result = "No actor selected.";
            return;
        }
        
        if (GameAction is null)
        {
            Result = "No action selected.";
            return;
        }
        
        GameAction.GetTargets(this);

        if (ActualTargets.Count == 0)
        {
            return;
        }
        
        GameAction.GetEvents(this);
        
        
    }
    
    // Results of the interaction.

    public List<Entity> ActualTargets { get; set; } = [];
    public List<InteractionEffects> Effects { get; set; } = [];
    
    public bool AllowRetry { get; set; } = false;
    public string Result { get; set; } = "";
    
    public string ApplyEvents()
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


/*
Okay, I think I've got an overall plan:

1. Funnel all information into the Interaction object. This will hold all the data and references needed to create the command object.
2. Interaction object then calculates the result of what would happen
a. The interaction calls calculate on the action object, which creates a bunch of events like DamageEvent() or HealEvent()
b. The entity is then told of these events, and modifiers them as per their modifier list.
c. we now have a list of what will happen to each entity, in order, For partial effects, we can actually perform a calculation mid way too I think using the list.
(For example, they swing at two enemies in whirlwind, but the sword breaks on the first enemy)
3. Finally, the list is settled and the side effects (events) can just be applied as they contain a reference to the entitiy.
*/
