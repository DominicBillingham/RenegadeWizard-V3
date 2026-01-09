namespace RenegadeWizardWasm.Core;

public abstract class InteractionEffect
{
    public required Entity Target { get; set; }
    public required Entity Actor { get; set; }
    public required Interaction Context { get; set; }
    public string Result { get; set; } = "";
    public bool HideResult { get; set; } = true;

    public void Apply()
    {
        Context.EffectLog.Add(this);
        
        foreach (var mod in Actor.Boosters)
        {
            mod.ModifyEffect(this);
        }

        foreach (var mod in Target.Modifiers)
        {
            mod.ModifyEffect(this);
        }

        if (Target.Replacer != null)
        {
            Target.Replacer.ModifyEffect(this);
            return;
        }
        
        Core();
        
    }
    protected abstract void Core();
}

public class DamageEffect : InteractionEffect
{
    public int Damage { get; set; }
    protected override void Core()
    {
        Result += $"{Target.Name} takes {Damage} damage";
        Target.Hitpoints -= Damage;
    }
}

public class LiftEffect : InteractionEffect
{
    public int LiftOverflow { get; set; }
    protected override void Core()
    {
        LiftOverflow = Actor.Strength - Target.Weight;
        if (LiftOverflow > 0)
        {
            Result = $"{Actor.Name} lifts {Target.Name} ";
        }
        else
        {
            Result = $"{Actor.Name} tries to lift {Target.Name} but fails.";
        }
    }
}

public class CharmEffect : InteractionEffect
{
    public int LiftOverflow { get; set; }
    protected override void Core()
    {
        LiftOverflow = Actor.Strength - Target.Weight;
        if (LiftOverflow > 0)
        {
            Result = $"{Actor.Name} lifts {Target.Name} ";
        }
        else
        {
            Result = $"{Actor.Name} tries to lift {Target.Name} but fails.";
        }
    }
}

public class ContactEffect : InteractionEffect
{
    public int LiftOverflow { get; set; }
    protected override void Core()
    {
        LiftOverflow = Actor.Strength - Target.Weight;
        if (LiftOverflow > 0)
        {
            Result = $"{Actor.Name} lifts {Target.Name} ";
        }
        else
        {
            Result = $"{Actor.Name} tries to lift {Target.Name} but fails.";
        }
    }
}





