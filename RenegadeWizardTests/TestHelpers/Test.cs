using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

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
            Relationship = PlayerRelationship.Friendly,
            IsPlayer = true
        };
    }

    public static Entity GetGlorb()
    {
        return new Entity
        {
            Name = "Glorb",
            Description = "The menance",
            MaxWounds = 3,
            Relationship = PlayerRelationship.Neutral,
        };
    }

    public static Entity GetSpikyMob()
    {
        return new Entity
        {
            Name = "SpikyMob",
            Description = "Description",
            MaxWounds = 3,
            Relationship = PlayerRelationship.Neutral,
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
            Relationship = PlayerRelationship.Hostile 
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
}