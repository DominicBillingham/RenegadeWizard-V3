using RenegadeWizardWasm.Core.Interactions.Effects;

namespace RenegadeWizardTests;

public class TagTests
{
    [Fact]
    public void DamageEffectReduceHearts()
    {
        var scene = TestHelper.GetTestScene();
        var effect = new DamageEffect(1, scene.Entities[0]);
        Assert.Equal(1, effect.Target.Wounds);
    }

}