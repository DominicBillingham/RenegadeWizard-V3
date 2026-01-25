using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Actions;

namespace RenegadeWizardWasm.Core.Entities;

public class Goose : Entity
{
    public  Goose()
    {
        Name = "Goose";
        Description = "One might say a rather foul fowl!";
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