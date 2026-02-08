using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Entities.Objects;

public class Window : Entity
{
    public Window() 
    {
        Name = "Window";
        Description = "A rather lovely window allowing for a rather quick descent.";
        Controller = Controller.Object;
        Hitpoints = 25;
        Stats[Stat.Strength] = 0;
        Stats[Stat.Dexterity] = 0;
        Stats[Stat.Intelligence] = 0;
    
        Stats[Stat.Weight] = 10;
        Stats[Stat.Size] = 7;
    
        Stats[Stat.Taste] = 0;
        Stats[Stat.FoodValue] = 0;
        
        Tags.Add(new FallHazard(Duration.Infinite));
        Tags.Add(new Immovable(Duration.Infinite));
        
    }
}