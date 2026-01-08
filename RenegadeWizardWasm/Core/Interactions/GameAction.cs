namespace RenegadeWizardWasm.Core;

public abstract class GameAction()
{
    public string Name { get; set; }
    public List<string> Aka { get; set; } = new();
    public List<string> Names => Aka.Append(Name).ToList();
    public abstract bool TryGetTargets(Interaction context);
    public abstract void StackEffects(Interaction context);
}

public class Punch : GameAction
{
    public Punch()
    {
        Name = "Punch";
        Aka = ["Hit", "Slap", "Whack"];
    }

    public override bool TryGetTargets(Interaction context)
    {
        try
        {
            context.ActualTargets.Add(context.DesiredTargets[0]);
            return true;
        }
        catch
        {
            context.Result = $"{context.Actor.Name} fails to find targets for {context.GameAction.Name}.";
            return false;
        }
    }
    
    public override void StackEffects(Interaction context)
    {
        var damage = new DamageEffect
        {
            Actor = context.Actor,
            Target = context.ActualTargets.First(), 
            Context = context,
            Damage = 1,
        };
        context.Effects.Add(damage);
    }
}

public class Throw : GameAction
{
    public Throw()
    {
        Name = "Throw";
        Aka = ["Hurl", "Yeet", "Toss"];
    }

    public override bool TryGetTargets(Interaction context)
    {
        try
        {
            context.ActualTargets.Add(context.DesiredTargets[0]);
            context.ActualTargets.Add(context.DesiredTargets[1]);
            return true;
        }
        catch
        {
            context.Result = $"{context.Actor.Name} fails to find targets for {context.GameAction.Name}.";
            return false;
        }
    }
    
    public override void StackEffects(Interaction context)
    {
        var lift = new LiftEffect()
        {
            Actor = context.Actor,
            Target = context.ActualTargets[0], 
            Context = context,
        };
        context.Effects.Add(lift);


        if (lift.LiftOverflow > 0)
        {
            var damage = new DamageEffect
            {
                Actor = context.Actor,
                Target = context.ActualTargets[1], 
                Context = context,
                Damage = lift.LiftOverflow,
            };
            context.Effects.Add(damage);
            
        }
        
    }
}