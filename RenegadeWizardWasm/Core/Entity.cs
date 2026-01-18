
using System.Diagnostics.CodeAnalysis;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions;
using RenegadeWizardWasm.Core.Interactions.Actions;
using RenegadeWizardWasm.Core.Interactions.Modifiers;

namespace RenegadeWizardWasm.Core;

public abstract class Entity
{
    
    // All modifications to any entity shoud go through their setter, in case if they have something like ignore fire damage.
    // Likewise, you should only get the value using the getter in case if they have a modifier like something boosting their strentth.
    // Ideally, all fields should be private to prevent mistakes from being made.
    
    public string  Name { get; set; }
    public string Description { get; set; } = "";
    public List<string> Aka { get; set; } = new List<string>();
    public List<string> Names => Aka.Append(Name).ToList();
    public int Hitpoints { get; set; }
    public Controller Controller { get; set; }
    public List<GameAction> Actions { get; set; } = new List<GameAction>();
    public List<Modifier> Modifiers { get; set; } = [];
    public Modifier? Replacer { get; set; }
    public Faction Faction { get; set; }

    public int GetStat(Stat stat)
    {
        int temp = Stats[stat];
        foreach (Modifier mod in Modifiers)
        {
            mod.ModifyStats(stat , ref temp);
        }
        return temp;
    }
    
    public void SetStat(Stat stat, int value)
    {
        Stats[stat] = value;
    }

    public Dictionary<Stat, int> Stats { get; init; } = new()
    {
        // Gameplay
        { Stat.Strength, 5 },
        { Stat.Dexterity, 5 },
        { Stat.Intelligence, 5 },
        
        // Physical
        { Stat.Weight, 5 },
        { Stat.Size, 5 },
        
        // Senses
        { Stat.Taste, 5 },
        { Stat.FoodValue, 5 }
    };

}

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


public class Player : Entity
{
    public Player()
    {
        Name = "Player";
        Description = "You are the wizard.";
        Controller = Controller.Player;
        Hitpoints = 10;
        
        Actions.Add(new Punch());
        Actions.Add(new Throw());
        Actions.Add(new Consume());
        Actions.Add(new Charm());
        
        Stats[Stat.Strength] = 5;
        Stats[Stat.Dexterity] = 5;
        Stats[Stat.Intelligence] = 5;
        
        Stats[Stat.Weight] = 5;
        Stats[Stat.Size] = 5;
        
        Stats[Stat.Taste] = 5;
        Stats[Stat.FoodValue] = 5;
    }
}


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

public class Door : Entity
{
    public Door() 
    {
        Name = "Door";
        Description = "A door made of wood.";
        Controller = Controller.Object;
        Hitpoints = 5;
        
        Stats[Stat.Strength] = 0;
        Stats[Stat.Dexterity] = 0;
        Stats[Stat.Intelligence] = 0;
    
        Stats[Stat.Weight] = 6;
        Stats[Stat.Size] = 6;
    
        Stats[Stat.Taste] = 3;
        Stats[Stat.FoodValue] = 0;
        
    }
}