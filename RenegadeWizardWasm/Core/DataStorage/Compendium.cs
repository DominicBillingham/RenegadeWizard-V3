using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions;
using RenegadeWizardWasm.Core.Interactions.Actions;
using RenegadeWizardWasm.Core.Interactions.Entities;
using RenegadeWizardWasm.Core.Interactions.Tags;

namespace RenegadeWizardWasm.Core.DataStorage;

public class Compendium
{
    public List<CompendiumEntry> Tags { get; set; } = new();
    public List<CompendiumEntry> Actions { get; set; }= new();
    public List<CompendiumEntry> Creatures { get; set; }= new();
    public List<CompendiumEntry> Objects { get; set; }= new();
    public List<CompendiumEntry> Achievements { get; set; }= new();


    public void AddEntry(Entity entity)
    {
        if (entity.Controller == Controller.Object)
        {
            Objects.Add(new CompendiumEntry(entity));
        }
        else
        {
            Creatures.Add(new CompendiumEntry(entity));
        }
    }
    public void AddEntry(GameAction action)
    {
        Actions.Add(new CompendiumEntry(action));
    }
    public void AddEntry(Tag tag)
    {
        Tags.Add(new CompendiumEntry(tag));
    }
    
}

public class CompendiumEntry
{
    public bool isUnlocked { get; set; } = true;
    public string LockedText { get; set; } = "";
    public string UnlockedText { get; set; } = "";

    public CompendiumEntry(Entity entity)
    {
        UnlockedText = entity.Description;
    }

    public CompendiumEntry(GameAction action)
    {
        UnlockedText = action.Description;
    }

    public CompendiumEntry(Tag tag)
    {
        UnlockedText = tag.Description;
    }
    
}