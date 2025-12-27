
namespace RenegadeWizardWasm.Core;


public class GameActionResult
{
    public string Text => string.Join(". ", Strands);
    
    public List<string> Strands = [];
    public bool AllowRetry { get; set; } = false;
}

public abstract class GameAction()
{
    
    public string Name { get; set; }
    public List<string> Aka { get; set; } = new();
    public List<string> Names => Aka.Append(Name).ToList();
    public abstract GameActionResult Resolve(Entities actor, IReadOnlyCollection<Entities> allTargets, List<Entities> desiredTargets);
}


public class Punch : GameAction
{
    public Punch()
    {
        Name = "Punch";
        Aka = ["Hit", "Slap", "Whack"];
    }

    public override GameActionResult Resolve(Entities actor, IReadOnlyCollection<Entities> allTargets, List<Entities> desiredTargets)
    {
        var result = new GameActionResult();
        
        var target = desiredTargets.FirstOrDefault();
        result.Strands.Add($"{actor.Name} punches {target.Name}");
        target.ApplyDamage(result, 3);
        return result;
    }
}

public class Throw : GameAction
{

    public Throw() 
    {
        Name = "Throw";
        Aka = ["Hurl", "Yeet", "Toss"];
    }

    public override GameActionResult Resolve(Entities actor, IReadOnlyCollection<Entities> allTargets, List<Entities> desiredTargets)
    {
        var result = new GameActionResult();

        var item = desiredTargets.FirstOrDefault();

        if (item == null)
        {
            result.AllowRetry = true;
            result.Strands.Add($"{actor.Name} tries to an throw an item, but no item is found.");
            return result;
        }
        
        desiredTargets.Remove(item);
        
        var target = desiredTargets.FirstOrDefault();
        
        if (target == null)
        {
            result.AllowRetry = true;
            result.Strands.Add($"{actor.Name} tries to an throw an item, but no target is found.");
            return result;
        }

        if (actor.Strength > item.Weight)
        {
            result.Strands.Add($"{actor.Name} <powerfully> throws #gn {item.Name} # at {target.Name}");
            target.ApplyDamage(result, item.Weight);
        }
        else
        {
            result.Strands.Add($"{actor.Name} fails to lift {item.Name}!");
        }
        
        return result;
    }
}
