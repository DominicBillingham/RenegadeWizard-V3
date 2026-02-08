using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Actions;

namespace RenegadeWizardWasm.Core.Interactions.Entities.Creatures;

public class GrimGooser : Entity
{
    
    public  GrimGooser()
    {
        Name = "GrimGooser";
        Description = "Spooky scary geese send shivers down your spine!";
        Controller = Controller.Npc;
        Hitpoints = 5;
        
        Actions.Add(new Peck());
        
        Stats[Stat.Strength] = 2;
        Stats[Stat.Dexterity] = 2;
        Stats[Stat.Intelligence] = 2;
    
        Stats[Stat.Weight] = 3;
        Stats[Stat.Size] = 2;
    
        Stats[Stat.Taste] = 7;
        Stats[Stat.FoodValue] = 6;
        
        
    }
}