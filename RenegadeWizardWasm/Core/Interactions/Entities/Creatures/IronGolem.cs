using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Actions;

namespace RenegadeWizardWasm.Core.Interactions.Entities.Creatures;

public class IronGolem : Entity
{
    public IronGolem()
    {
        Name = "IronGolem";
        Description = "A hulking monster, immune to most damage.";
        Controller = Controller.Npc;
        Hitpoints = 25;

        Actions.Add(new Punch());

        Stats[Stat.Strength] = 8;
        Stats[Stat.Dexterity] = 4;
        Stats[Stat.Intelligence] = 4;
        
        Stats[Stat.Weight] = 7;
        Stats[Stat.Size] = 7;
        
        Stats[Stat.Taste] = 3;
        Stats[Stat.FoodValue] = 1;
    }
}
