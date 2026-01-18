using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Actions;
using RenegadeWizardWasm.Core.Interactions.Modifiers;

namespace RenegadeWizardWasm.Core.Entities;

public class IronGolem : Entity
{
    public IronGolem()
    {
        Name = "IronGolem";
        Description = "A hulking monster, immune to most damage.";
        Controller = Controller.Npc;
        Hitpoints = 25;

        Actions.Add(new Punch());
        Modifiers.Add(new Armour(5));

        Stats[Stat.Strength] = 8;
        Stats[Stat.Dexterity] = 4;
        Stats[Stat.Intelligence] = 4;
        
        Stats[Stat.Weight] = 7;
        Stats[Stat.Size] = 7;
        
        Stats[Stat.Taste] = 3;
        Stats[Stat.FoodValue] = 1;
    }
}
