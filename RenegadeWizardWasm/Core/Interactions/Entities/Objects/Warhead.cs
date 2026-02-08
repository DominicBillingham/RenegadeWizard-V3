using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.Entities;

public class Warhead : Entity
{
    public Warhead() 
    {
        Name = "Warhead";
        Aka = ["Nuke"];
        Description = "Hmm, I'm fairly sure this is an OSHA violation.";
        Controller = Controller.Object;
        Hitpoints = 5;
        Stats[Stat.Strength] = 0;
        Stats[Stat.Dexterity] = 0;
        Stats[Stat.Intelligence] = 0;
    
        Stats[Stat.Weight] = 4;
        Stats[Stat.Size] = 4;
    
        Stats[Stat.Taste] = 0;
        Stats[Stat.FoodValue] = 0;
        
        Tags.Add(new Explosive(Duration.Permanent, 9999));
    }
}