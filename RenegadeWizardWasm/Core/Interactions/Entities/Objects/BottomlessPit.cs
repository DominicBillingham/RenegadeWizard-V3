using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Interactions.Entities.Objects;

public class BottomlessPit : Entity
{
    public BottomlessPit() 
    {
        Name = "BottomlessPit";
        Aka = ["Pit"];
        Description = "Oh, I think there's some coins at the bottom!";
        Controller = Controller.Object;
        Hitpoints = 25;
        
        Stats[Stat.Strength] = 0;
        Stats[Stat.Dexterity] = 0;
        Stats[Stat.Intelligence] = 0;
    
        Stats[Stat.Weight] = 10;
        Stats[Stat.Size] = 10;
    
        Stats[Stat.Taste] = 0;
        Stats[Stat.FoodValue] = 0;
        
        Tags.Add(new FallHazard(Duration.Permanent));
        Tags.Add(new Immovable(Duration.Permanent));
        
    }
}