namespace RenegadeWizardWasm.Core;

public abstract class GameAction()
{
    public string Name { get; set; }
    public List<string> Aka { get; set; } = new();
    public List<string> Names => Aka.Append(Name).ToList();
    public abstract void GetTargets(Interaction context);
    public abstract void GetEffects(Interaction context);
}

public class Punch : GameAction
{
    public Punch()
    {
        Name = "Punch";
        Aka = ["Hit", "Slap", "Whack"];
    }

    public override void GetTargets(Interaction context)
    {
        Entity? target = context.DesiredTargets.FirstOrDefault();
        if (target is null)
        {
            context.Result = $"{context.Actor.Name} fails to find a target to {context.GameAction.Name}.";
            return;
        }

        context.ActualTargets.Add(target);
    }
    
    public override void GetEffects(Interaction context)
    {
        var dEvent = new DamageEffects
        {
            Damage = 1,
            Targets = context.ActualTargets, 
        };
        context.Effects.Add(dEvent);
    }
}