using RenegadeWizardWasm.Core.Errors;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardWasm.Core.Interactions.Actions;

public abstract class BaseAction
{
    public abstract ActionIdentity ActionIdentity { get; set; }
    public abstract void Execute(ActionContext context);
    
    public Entity GetEntity(ActionContext context, int index)
    {
        try
        {
            return context.IntendedTargets[index];
        }
        catch
        {
            throw new BadInputException("You haven't selected enough targets");
        }
    }
    
    public Entity? GetOptionalEntity(ActionContext context, int index)
    {
        try
        {
            return context.IntendedTargets[index];
        }
        catch
        {
            return null;
        }
    }
}