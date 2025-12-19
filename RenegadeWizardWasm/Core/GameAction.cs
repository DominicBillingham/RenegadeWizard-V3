namespace RenegadeWizardWasm.Core;

public abstract class GameAction
{
    public virtual string  Name { get; set; }
    public virtual List<string> Aka { get; set; } = new();
    public List<string> Names => Aka.Append(Name).ToList();
    public int Damage { get; set; }
    public int Heal { get; set; }

}

public class Punch : GameAction
{
    public Punch()
    {
        Damage = 3;
    }
}

public class Heal : GameAction
{
    public Heal()
    {
        Heal = 3;
    }
}
