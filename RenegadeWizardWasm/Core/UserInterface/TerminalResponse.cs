using RenegadeWizardWasm.Core.Interactions;

namespace RenegadeWizardWasm.Core.UserInterface;


public class TerminalResponse()
{
    // This get is used to format the list of strings for the terminal
    // This way, strings can be added in any order and still formatted correctlys
    public List<string> Text
    {
        get
        {
            List<string> _text = new List<string>();

            if (!string.IsNullOrWhiteSpace(PlayerInput))
            {
                _text.Add(" ");
                _text.Add($"> {PlayerInput}");
            }

            if (DebugLines.Any())
            {
                _text.AddRange(DebugLines);
            }
            
            if (NarrationLines.Any()) 
            {
                _text.AddRange(NarrationLines);
            }
            
            if (CombatLines.Any())
            {
                _text.AddRange(CombatLines);
            }

            if (SceneLines.Any())
            {
                _text.AddRange(SceneLines);
            }

            return _text;
        }
    }

    public string PlayerInput { get; set; } = "";
    public List<string> DebugLines { get; set; } = new();
    public List<string> CombatLines { get; set; } = new();
    public List<string> SceneLines { get; set; } = new();
    public List<string> NarrationLines { get; set; } = new();
    
    
    // This is a list of data that can be used to populate the main view with information.
    public List<TerminalCard> CreatureCards = new();
    public List<TerminalCard> ObjectCards = new();
    public List<TerminalCard> ActionCards = new();
    
    // Used for the auto complete when pressing tab
    public List<string> EntityNames = new();
    public List<string> ActionNames = new();

}

public class TerminalCard
{
    public string Description { get; set; } = "";
    public string Name { get; set; } = "";
    
    public int? Hitpoints { get; set; }
    
    public TerminalCard(Entity entity)
    {
        Name = entity.Name;
        Description = entity.Description;
        Hitpoints = entity.Hitpoints;
    }

    public TerminalCard(GameAction action)
    {
        Name = action.Name;
        Description = action.Description;
    }
    
}