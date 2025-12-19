using RenegadeWizardWasm.Core.Enums;

namespace RenegadeWizardWasm.Core;

public class Entity
{
    public string  Name { get; set; }
    public List<string> Aka { get; set; } = new List<string>();
    public List<string> Names => Aka.Append(Name).ToList();
    public int Hitpoints { get; set; }
    
    public Controller Controller { get; set; }

    public List<GameAction> Actions { get; set; } = new List<GameAction>();

}


public class Player : Entity
{
    public Player()
    {
        Name = "Player";
        Controller = Controller.Player;
        Hitpoints = 10;
        Actions.Add(new Punch());
        Actions.Add(new Heal());
    }
}

public class Goblin : Entity
{
    public Goblin()
    {
        Name = "Goblin";
        Controller = Controller.Npc;
        Hitpoints = 5;
        Actions.Add(new Punch());
    }
}