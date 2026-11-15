using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;
using RenegadeWizardWasm.Core.Services;

namespace RenegadeWizardTests;

public static class Test
{
    // Static class useful for creating entities for testing
    public static Entity GetPlayer()
    {
        return new Entity
        {
            Name = "Player",
            Description = "The player character",
            MaxWounds = 10,
            MaxStress = 10,
            Relationship = PlayerRelationship.Friendly,
            IsPlayer = true,
            Size = Size.Medium,
        };
    }

    public static Entity GetGlorb()
    {
        return new Entity
        {
            Name = "Glorb",
            Description = "The menance",
            MaxWounds = 3,
            MaxStress = 10,
            Relationship = PlayerRelationship.Neutral,
            Size = Size.Medium,
        };
    }

    public static Entity GetSpikyMob()
    {
        return new Entity
        {
            Name = "SpikyMob",
            Description = "Description",
            MaxWounds = 3,
            MaxStress = 10,
            Relationship = PlayerRelationship.Neutral,
            Size = Size.Medium,
            Tags = [Tags.Spiky]
        };
    }
    
    public static Entity GetGrendal()
    {
        return new Entity
        {
            Name = "Grendal",
            Description = "The terror", 
            MaxWounds = 3, 
            MaxStress = 10,
            Size = Size.Medium,
            Relationship = PlayerRelationship.Aggressive 
        };
    }
    
    public static Entity GetTuba()
    {
        return new Entity
        {
            Name = "Tuba", 
            Description = "The horror",
            MaxWounds = 3,
            MaxStress = 10,
            Size = Size.Medium,
            Relationship = PlayerRelationship.Hostile 
        };
    }
    
    public static Entity GetTable()
    {
        return new Entity
        {
            Name = "Table", 
            Description = "The table",
            MaxWounds = 3,
            MaxStress = 3,
            Size = Size.Medium,
            Relationship = PlayerRelationship.Neutral 
        };
    }
    
    public static SceneManager GetBasicScene()
    {
        var glorb = Test.GetGlorb();
        var grendal = Test.GetGrendal();
        var tuba = Test.GetTuba();
        var player = Test.GetPlayer();
        return new SceneManager { Entities = new List<Entity> { player, glorb, grendal, tuba } };
    }

    public static ActionContext GetBasicActionContext()
    {
        var glorb = Test.GetGlorb();
        var grendal = Test.GetGrendal();
        var tuba = Test.GetTuba();
        var player = Test.GetPlayer();
        var Entities = new List<Entity> { player, glorb, grendal, tuba };
        
        return new ActionContext
        {
            Roller = new DiceRoller(),
            Executor = player,
            IntendedTargets = new List<Entity> { glorb },
            AllEntities = Entities,
        };
    }
    
}