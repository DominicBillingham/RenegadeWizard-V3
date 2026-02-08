using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Actions;
using RenegadeWizardWasm.Core.Interactions.Tags;

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
        Actions.Add(new Reaper());
        Actions.Add(new MarkForDeath());
        
        Tags.Add(new Undead(Duration.Infinite));

        
        Stats[Stat.Strength] = 4;
        Stats[Stat.Dexterity] = 6;
        Stats[Stat.Intelligence] = 8;
    
        Stats[Stat.Weight] = 5;
        Stats[Stat.Size] = 5;
    
        Stats[Stat.Taste] = 3;
        Stats[Stat.FoodValue] = 2;
        
        
    }
}