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
    
    private static Entity GetBasicEntity()
    {
        return new Entity
        {
            Name = "Entity",
            Description = "Description",
            MaxWounds = 3,
            MaxStress = 10,
            Relationship = PlayerRelationship.Neutral,
            Size = Size.Medium,
        };
    }

    public static Entity GetGlorb()
    {
        var entity = GetBasicEntity();
        entity.Name = "Glorb";
        entity.Description = "The menance";
        return entity;
    }

    public static Entity GetSpikyMob()
    {
        var entity = GetBasicEntity();
        entity.Name = "SpikyMob";
        entity.Tags = [Tags.Spiky];
        return entity;
    }
    
    public static Entity GetGrendal()
    {
        var entity = GetBasicEntity();
        entity.Name = "Grendal";
        entity.Description = "The terror";
        entity.Relationship = PlayerRelationship.Aggressive;
        return entity;
    }
    
    public static Entity GetTuba()
    {
        var entity = GetBasicEntity();
        entity.Name = "Tuba";
        entity.Description = "The horror";
        entity.Relationship = PlayerRelationship.Hostile;
        return entity;
    }
    
    public static Entity GetTable()
    {
        var entity = GetBasicEntity();
        entity.Name = "Table";
        entity.Description = "The table";
        entity.MaxStress = 3;
        return entity;
    }

    public static Entity GetGoblin()
    {
        var entity = GetBasicEntity();
        entity.Name = "Goblin";
        entity.Description = "A mischievous goblin";
        return entity;
    }

    public static Entity GetSpikePit()
    {
        var entity = GetBasicEntity();
        entity.Name = "SpikePit";
        entity.Description = "A pit of sharp spikes";
        entity.Tags = [Tags.Spiky];
        return entity;
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