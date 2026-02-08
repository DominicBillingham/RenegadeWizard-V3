using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Actions;

namespace RenegadeWizardWasm.Core.Entities;

public class Goblin : Entity
{
    public Goblin()
    {
        Name = "Goblin";
        Description = "A rather wretched little creature.";
        Controller = Controller.Npc;
        Hitpoints = 5;
        
        Actions.Add(new Punch());
        
        Stats[Stat.Strength] = 3;
        Stats[Stat.Dexterity] = 3;
        Stats[Stat.Intelligence] = 3;
    
        Stats[Stat.Weight] = 4;
        Stats[Stat.Size] = 4;
    
        Stats[Stat.Taste] = 2;
        Stats[Stat.FoodValue] = 4;
        
    }
}
