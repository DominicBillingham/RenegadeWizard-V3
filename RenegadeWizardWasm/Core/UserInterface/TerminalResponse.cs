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
                //_text.AddRange(DebugLines);
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
    public List<Entity> Creatures = new();
    public List<Entity> Objects = new();
    
    // Used for the auto complete when pressing tab
    public List<string> EntityNames = new();
    public List<string> ActionNames = new();

}