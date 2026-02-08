using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Entities.Objects;

public class Door : Entity
{
    public Door() 
    {
        Name = "Door";
        Description = "A door made of wood.";
        Controller = Controller.Object;
        Hitpoints = 5;
        
        Stats[Stat.Strength] = 0;
        Stats[Stat.Dexterity] = 0;
        Stats[Stat.Intelligence] = 0;
    
        Stats[Stat.Weight] = 6;
        Stats[Stat.Size] = 6;
    
        Stats[Stat.Taste] = 3;
        Stats[Stat.FoodValue] = 0;
        
        Tags.Add(new Attached(Duration.Permanent, 10));
        
    }
}

