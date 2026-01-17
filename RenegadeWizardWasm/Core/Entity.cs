
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
    public List<Modifier> Boosters { get; set; } = [];
    public List<Modifier> Modifiers { get; set; } = [];
    public Modifier? Replacer { get; set; }

    public Faction Faction { get; set; }
    
    // Dimensions
    public int Size { get; set; } 
    
    // Skills
    public int Strength { get; set; } 
    
    // Senses
    public int Taste { get; set; }
    
    // Tool usage
    public int Weight { get; set; }
    public int FoodValue { get; set; } 

}

public class IronGolem : Entity
{
    public IronGolem()
    {
        Name = "IronGolem";
        Description = "A hulking monster, immune to most damage.";
        Controller = Controller.Npc;
        
        Actions.Add(new Punch());
        Modifiers.Add(new Armour(5));
        
        // Attributes        
        Hitpoints = 10;
        Strength = 10;

        // Dimensions
        Size = 15;
        Weight = 15;
        
        // Senses
        FoodValue = 0;
        Taste = 0;
        
    }
}


public class Player : Entity
{
    public Player()
    {
        Name = "Player";
        Description = "You are the wizard.";
        Controller = Controller.Player;
        
        Actions.Add(new Punch());
        Actions.Add(new Throw());
        Actions.Add(new Consume());
        Actions.Add(new Charm());
        
        // Attributes        
        Hitpoints = 10;
        Strength = 10;

        // Dimensions
        Size = 3;
        Weight = 3;
        
        // Senses
        FoodValue = 2;
        Taste = 3;
    }
}

public class Table : Entity
{
    public Table()
    {
        Name = "Table";
        Description = "A sturdy wooden table.";
        Controller = Controller.Object;
        
        // Attributes        
        Hitpoints = 10;
        Strength = 10;

        // Dimensions
        Size = 4;
        Weight = 10;
        
        // Senses
        FoodValue = 0;
        Taste = 1;
        
    }
}

public class Chair : Entity
{
    public Chair()
    {
        Name = "Chair";
        Description = "A simple wooden chair.";
        Controller = Controller.Object; 
        
        // Attributes        
        Hitpoints = 3;
        Strength = 3;

        // Dimensions
        Size = 2;
        Weight = 3;
        
        // Senses
        FoodValue = 0;
        Taste = 1;
    }
}
public class Goblin : Entity
{
    public Goblin()
    {
        Name = "Goblin";
        Description = "A rather wretched little creature.";
        Controller = Controller.Npc;
        Actions.Add(new Punch());
        
        // Attributes        
        Hitpoints = 6;
        Strength = 7;

        // Dimensions
        Size = 2;
        Weight = 5;
        
        // Senses
        FoodValue = 2;
        Taste = 4;
        
    }
}

public class Door : Entity
{
    public Door()
    {
        Name = "Door";
        Description = "A door made of wood.";
        Controller = Controller.Object;
        Actions.Add(new Punch());
        
        // Attributes        
        Hitpoints = 6;
        Strength = 7;

        // Dimensions
        Size = 2;
        Weight = 5;
        
        // Senses
        FoodValue = 2;
        Taste = 4;
        
    }
}