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
    public void DamageEffectReduceHearts()
    {
        var scene = TestHelper.GetTestScene();
        var effect = new DamageEffect(1, scene.Entities[0]);
        Assert.Equal(1, effect.Target.Wounds);
    }
    
    
    
    
    
}