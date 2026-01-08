namespace RenegadeWizardWasm.Core;

public abstract class InteractionEffect
{
    public required Entity Target { get; set; }
    public required Entity Actor { get; set; }
    public required Interaction Context { get; set; }
    public string Text { get; set; } = "";

    public abstract void Calculate();
    public abstract string Apply();
}

public class DamageEffect : InteractionEffect
{
    public int Damage { get; set; }

    public override void Calculate()
    {
        Text += $"{Target.Name} takes {Damage} damage";
        
        foreach (var mod in Target.Modifiers)
        {
            mod.ModifyEffect(this);
        }

    }
    public override string Apply()
    {
        
        Target.Hitpoints -= Damage;
        return Text;
    }
}

public class LiftEffect : InteractionEffect
{

    public int LiftOverflow { get; set; }
    
    public override void Calculate()
    {

        LiftOverflow = Actor.Strength - Target.Weight;
            
        if (LiftOverflow > 0)
        {
            Text = $"{Actor.Name} lifts {Target.Name} ";
        }
        else
        {
            Text = $"{Actor.Name} tries to lift {Target.Name} but fails.";
        }
        
        foreach (var mod in Target.Modifiers)
        {
            mod.ModifyEffect(this);
        }
        
    }
    public override string Apply()
    {
        return Text;
    }
}





// public class ThrowEffect() : InteractionEffects()
// {
//     
//     public int Damage { get; set; }
//
//     public override void Apply(Entity target)
//     {
//         foreach (var mod in Modifiers)
//         {
//             mod.ModifyEffect(this);
//         }
//
//         Text += $"{target.Name} takes {Damage} damage";
//
//         if (Modifiers.Any())
//         {
//             Text += $", modifed by [{string.Join(", ", Modifiers.Select(mod => mod.Name))}].";
//         }
//
//         target.Hitpoints -= Damage;
//     }
// }