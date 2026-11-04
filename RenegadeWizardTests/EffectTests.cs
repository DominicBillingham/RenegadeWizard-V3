using RenegadeWizardWasm.Core.Enums;
using RenegadeWizardWasm.Core.Interactions.Effects;

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
        var effect = new DamageEffect(1, testEnt);
        Assert.Equal(1, testEnt.Wounds);
    }
        
    [Fact]
    public void CharmEffect()
    {
        var testEnt = Test.GetGlorb();
        testEnt.Relationship = PlayerRelationship.Hated; // (0)
        Assert.Equal(1, (int)testEnt.Relationship); // Has it boosted by 1 level?
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
}