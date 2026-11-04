using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardTests;

public static class TestHelper
{
    public static SceneManager GetTestScene()
    {
        var scene = new SceneManager()
        {
            Entities = new List<Entity>()
            {
                new Entity { 
                    Name = "Glorb", 
                    Description = "The menance", 
                    MaxWounds = 3, 
                    Relationship = PlayerRelationship.Neutral 
                },
                new Entity
                {
                    Name = "Grendal",
                    Description = "The terror", 
                    MaxWounds = 3, 
                    Relationship = PlayerRelationship.Aggressive 
                },
                new Entity
                {
                    Name = "Tuba", 
                    Description = "The horror",
                    MaxWounds = 3,
                    Relationship = PlayerRelationship.Hostile 
                },
            }
        };
        return scene;
    }
    
    public static Entity GetTestEntity()
    {
        return new Entity { 
            Name = "Glorb", 
            Description = "The menance", 
            MaxWounds = 3, 
            Relationship = PlayerRelationship.Neutral 
        };
    }
    
}