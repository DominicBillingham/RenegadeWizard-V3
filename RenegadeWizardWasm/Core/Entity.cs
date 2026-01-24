
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
            temp = Math.Clamp(temp, 1, 10);
        }
        return temp;
    }
    
    public void SetStat(Stat stat, int value)
    {
        Stats[stat] = value;
    }

    public Dictionary<Stat, int> Stats { get; init; } = new()
    {
        // All stats range between 1 and 10.
        // 5 is the human baseline.
        
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