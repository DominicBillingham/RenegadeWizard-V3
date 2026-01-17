namespace RenegadeWizardWasm.Core.Interactions;


public abstract class Modifier
{
    public string Name { get; set; } = "";
    public abstract void ModifyEffect(InteractionEffect effect);

}
