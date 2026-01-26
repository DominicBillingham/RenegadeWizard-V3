using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions;

public abstract class InteractionEffect
{
    public ActionContext Context { get; set; }
    public string Result { get; set; } = "";
    public bool HideResult { get; set; } = false;
    
    public InteractionEffect(ActionContext context)
    {
        context.CombatLog.Add(this);
        Context = context;
    }
    
}

public class TestEffect : InteractionEffect
{
    public int LiftOverflow { get; set; } = 0;
    public TestEffect(ActionContext context) : base(context)
    {
        var actor = context.Actor;
        var target = context.DesiredTargets.FirstOrDefault();
        
        int actorStrength = actor.GetStat(Stat.Strength);
        int targetWeight = target.GetStat(Stat.Weight);
        
        LiftOverflow = actorStrength - targetWeight;
        if (LiftOverflow > 0)
        {
            Result = $"{actor.Name} <powerfully> <throws> {target.Name}. ";
        }
        else
        {
            Result = $"{actor.Name} tries to lift {target.Name} - <fails>.";
        }
    }
}

public class ForceMoveEffect : InteractionEffect
{
    public ForceMoveEffect(ActionContext context, Entity actor, Entity target) : base(context)
    {
        
        int actorStrength = actor.GetStat(Stat.Strength);
        int targetWeight = target.GetStat(Stat.Weight);

        if (target.Tags.FirstOrDefault(tag => tag is Attached) is Attached attached)
        {
            if (actorStrength > attached.AttachmentStrength)
            {
                Result = $"{actor.Name} rips {target.Name} from {attached.AttachedTo.Name}.";
            }
            else
            {
                Result = $"{actor.Name} tries to pull apart {target.Name} and {attached.AttachedTo.Name} - <fails>.";
                return;
            }
        }

        if (targetWeight > actorStrength)
        {
            Result = $"{actor.Name} tries to lift {target.Name} - <fails>.";
        }
        
        Result = $"{actor.Name} <powerfully> <throws> {target.Name}. ";
        
    }
}

public class CollisionEffect : InteractionEffect
{
    public CollisionEffect(ActionContext context, Entity target1, Entity target2) : base(context)
    {
        if (target1.Tags.FirstOrDefault(tag => tag is FallHazard) is Attached FallHazard)
        {
            Result = $"{target1.Name} falls off the map...";
            return;
        }

        if (target2.Tags.FirstOrDefault(tag => tag is FallHazard) is Attached FallHazard2)
        {
            Result = $"{target2.Name} never stops falling...";
            return;
        }
    }
}