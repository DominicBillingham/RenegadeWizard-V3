using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core.Entities;

public class Chair : Entity
{
    public Chair()
    {
        Name = "Chair";
        Description = "A simple wooden chair.";
        Controller = Controller.Object; 
        Hitpoints = 5;
        
        Stats[Stat.Strength] = 0;
        Stats[Stat.Dexterity] = 0;
        Stats[Stat.Intelligence] = 0;
    
        Stats[Stat.Weight] = 4;
        Stats[Stat.Size] = 3;
    
        Stats[Stat.Taste] = 3;
        Stats[Stat.FoodValue] = 0;
  
    }
}
