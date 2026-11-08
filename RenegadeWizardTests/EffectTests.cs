using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;
using RenegadeWizardWasm.Core.Models;

namespace RenegadeWizardTests;

public class EffectTests
{
    
    // Damage Effect -> Removes a heart from the creature
    // Charm Effect -> Ups a creatures' relationship level
    // Topple Effect -> Gives the creature the
    // Force Move Effect -> Gives the creature
    // Contact Effect -> Does nothing, but triggers certain tags.
    // Stun Effect -> Prevent the creature from taking a turn.
    
    [Fact]
    public void DamageEffect()
    {
        var testEnt = Test.GetGlorb();
        var effect = new DamageEffect
        {
            Context = new ActionContext(),
            Target = testEnt,
            Damage = 1,
        };
        effect.Execute();
        Assert.Equal(1, testEnt.Wounds);
    }
        
    [Fact]
    public void CharmEffect()
    {
        var testEnt = Test.GetGlorb();
        Assert.Equal(1, (int)testEnt.Relationship);
    }
    
    [Fact]
    public void KnockdownEffect()
    {
        var testEnt = Test.GetGlorb();
        Assert.Contains(Tags.Toppled, testEnt.Tags);
    }

    [Fact]
    public void StunnedEffect()
    {
        var testEnt = Test.GetGlorb();
        Assert.Contains(Tags.Stunned, testEnt.Tags);
    }

    [Fact]
    public void BurnEffect()
    {
        var testEnt = Test.GetGlorb();
        Assert.Contains(Tags.Burning, testEnt.Tags);
    }

    [Fact]
    public void ForceMoveEffect()
    {
        var testEnt = Test.GetGlorb();

    }

    [Fact]
    public void ConsumeEffect()
    {
        var testEnt = Test.GetGlorb();
        Assert.True(testEnt.IsDefeated);
    }
    
    [Fact]
    public void ContactEffect()
    {
        var testEnt = Test.GetGlorb();
    }

    [Fact]
    public void NoiseEffect()
    {
        var testEnt = Test.GetGlorb();
    }
    
    [Fact]
    public void MoveEffect()
    {
        var testEnt = Test.GetGlorb();
    }

    public void HealEffect()
    {
        var testEnt = Test.GetGlorb();
        testEnt.Wounds = 2;
        Assert.Equal(0, testEnt.Wounds);
    }
    
    
    
}