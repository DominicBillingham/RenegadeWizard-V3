using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Actions;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Entities;

public class Player : Entity
{
    public Player()
    {
        Name = "Player";
        Description = "You are the wizard";
        Controller = Controller.Player;
        Hitpoints = 10;
        
        Actions.Add(new Punch());
        Actions.Add(new Throw());
        Actions.Add(new Consume());
        Actions.Add(new Charm());
        Actions.Add(new Kick());
        
        Stats[Stat.Strength] = 5;
        Stats[Stat.Dexterity] = 5;
        Stats[Stat.Intelligence] = 5;
        
        Stats[Stat.Weight] = 5;
        Stats[Stat.Size] = 5;
        
        Stats[Stat.Taste] = 5;
        Stats[Stat.FoodValue] = 5;
    }
}
